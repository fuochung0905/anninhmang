using AutoDependencyRegistration.Attributes;
using ENCRYPT;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MODELS;
using System.Data;

namespace REPONSITORY.HETHONG.LICENSE
{
    [RegisterClassAsTransient]
    public class LICENSEService : ILICENSEService
    {
        private IEncryptDecrypt _encryptDecrypt;
        private IConfiguration _config;

        public LICENSEService(
            IEncryptDecrypt encryptDecrypt,
            IConfiguration config
        )
        {
            _encryptDecrypt = encryptDecrypt;
            _config = config;
        }

        //GET CODE REGISTER
        public BaseResponse<string> GetCodeRegister()
        {
            var response = new BaseResponse<string>();
            try
            {
                IDbConnection connection = new SqlConnection(_encryptDecrypt.DecryptText(_config.GetConnectionString("DatabaseContext")));
                response.Data = _encryptDecrypt.GetRegistrationCode(connection.Database);
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
