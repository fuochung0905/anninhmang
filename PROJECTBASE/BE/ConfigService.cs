using AutoDependencyRegistration;
using AutoMapper;
using BE.Helper;
using DATABASECONNECT.Infrastructure;
using ENCRYPT;
using ENTITIES.DBContent;
using FluentValidation.AspNetCore;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using MODELS.HETHONG.TAIKHOAN.Requests;
using System.Reflection;

namespace BE
{
    public static class ConfigService
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        {
            //SYSTEM
            services.AddSingleton(configuration);
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //LICENSE
            services.AddTransient<ILicense, ENCRYPT.License>();
            services.AddTransient<IEncryptDecrypt, EncryptDecrypt>(obj =>
            {
                return new EncryptDecrypt(configuration["License:Key"]);
            });
            //MAPPER
            var allREPONSITORY = Assembly.GetEntryAssembly()
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Where(x => x.FullName.Contains("REPONSITORY"));
            var mappigConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(allREPONSITORY);
                mc.CreateMap<DateOnly?, DateTime?>().ConvertUsing(new DateTimeTypeConverter());
                mc.CreateMap<DateTime?, DateOnly?>().ConvertUsing(new DateOnlyTypeConverter());
            });
            IMapper mapper = mappigConfig.CreateMapper();
            services.AddSingleton(mapper);
            //FLUENT
            services.AddMvc(config => { config.Filters.Add<AttributePermission>(); })
                .AddFluentValidation(config =>
                {
                    config.ImplicitlyValidateChildProperties = true;
                    config.DisableDataAnnotationsValidation = true;
                    config.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>();
                })
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            var sp = services.BuildServiceProvider();
            //SQL SERVER
            services.AddDbContext<PROJECTBASEContext>(DATABASECONNECT.Utils.ConfigService.GetDBContextOption(sp.GetService<IEncryptDecrypt>(), configuration));
            services.AddTransient<IUnitOfWork, UnitOfWork<PROJECTBASEContext>>();
            //LOG4NET
            Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
            if (hierarchy != null && hierarchy.Configured)
            {
                foreach (IAppender appender in hierarchy.GetAppenders())
                {
                    if (appender is AdoNetAppender)
                    {
                        var adoNetAppender = (AdoNetAppender)appender;
                        DATABASECONNECT.Utils.ConfigService.UpdateLogAppender(sp.GetService<IEncryptDecrypt>(), configuration, ref adoNetAppender);
                        adoNetAppender.ActivateOptions();
                    }
                }
            }
            //ALL SERVICE
            services.AutoRegisterDependencies();
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<DateOnly?, DateTime?>
    {
        public DateTime? Convert(DateOnly? source, DateTime? destination, ResolutionContext context)
        {
            return source.HasValue ? source.Value.ToDateTime(TimeOnly.Parse("00:00:00")) : null;
        }
    }

    public class DateOnlyTypeConverter : ITypeConverter<DateTime?, DateOnly?>
    {
        public DateOnly? Convert(DateTime? source, DateOnly? destination, ResolutionContext context)
        {
            return source.HasValue ? DateOnly.FromDateTime(source.Value) : null;
        }
    }
}