using BE.Controllers.HETHONG;
using BE.Helper;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using MODELS.HETHONG.TAIKHOAN.Requests;
using REPONSITORY.HETHONG.TAIKHOAN;
using System.Net;
using System.Net.Sockets;

namespace BE.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController<T> : ControllerBase
    {
        protected ILog _logger;
        private bool _logOnOff = false;

        public BaseController()
        {
            //Load log4net Configuration
            XmlConfigurator.Configure();
            //Get logger
            _logger = LogManager.GetLogger(typeof(T));
            //Get logger on/off app config
            #if DEBUG
            
            #else
               _logOnOff = true;
            #endif
        }

        #region Menthod
        [NonAction]
        public void LogInfo(string message, Exception ex)
        {
            try
            {
                if (_logOnOff)
                {
                    #region Property
                    log4net.ThreadContext.Properties["IpAddress"] = GetIPAddress();
                    #endregion
                    _logger.Info(message, ex);
                }
                
            }
            catch
            { }
        }

        [NonAction]
        public void LogError(string message, Exception ex)
        {
            try
            {
                if (_logOnOff)
                {
                    #region Property
                    log4net.ThreadContext.Properties["IpAddress"] = GetIPAddress();
                    #endregion
                    _logger.Error(message, ex);
                }
            }
            catch
            { }
        }

        [NonAction]
        public void LogWarn(string message)
        {
            try
            {
                if (_logOnOff)
                {
                    #region Property
                    log4net.ThreadContext.Properties["IpAddress"] = GetIPAddress();
                    #endregion
                    _logger.Warn(message);
                }
                
            }
            catch
            { }
        }

        /// <summary>
        /// Nội dung thông báo khi Insert
        /// </summary>
        /// <param name="id">ID đối tượng Insert</param>
        /// <returns></returns>
        [NonAction]
        public string GetInsertMessage(int id)
        {
            try
            {
                var user = HttpContext.User.Identity.Name;
                string result = string.Format("{0} / Thêm dòng dữ liệu ID: {1}", user, id.ToString());

                return result;
            }
            catch
            { }

            return "";
        }

        /// <summary>
        /// Nội dung thông báo khi Update
        /// </summary>
        /// <param name="id">ID đối tượng Update</param>
        /// <returns></returns>
        [NonAction]
        public string GetUpdateMessage(int id)
        {
            try
            {
                var user = HttpContext.User.Identity.Name;
                string result = string.Format("{0} / Cập nhật dòng dữ liệu ID: {1}", user, id.ToString());

                return result;
            }
            catch { }

            return "";
        }

        /// <summary>
        /// Nội dung thông báo khi Update
        /// </summary>
        /// <param name="id">ID đối tượng Update</param>
        /// <param name="message">Nội dung thông báo khác</param>
        /// <returns></returns>
        [NonAction]
        public string GetUpdateMessage(int id, string message)
        {
            try
            {
                var user = HttpContext.User.Identity.Name;
                string result = string.Format("{0} / {1}: {2}", user, message, id.ToString());

                return result;
            }
            catch { }

            return "";
        }

        /// <summary>
        /// Nội dung thông báo khi Delete
        /// </summary>
        /// <param name="id">ID đối tượng Delete</param>
        /// <returns></returns>
        [NonAction]
        public string GetDeleteMessage(int id)
        {
            try
            {
                var user = HttpContext.User.Identity.Name;
                string result = string.Format("{0} / Xóa dòng dữ liệu ID: {2}", user, id.ToString());

                return result;
            }
            catch { }

            return "";

        }

        /// <summary>
        /// Lấy địa chỉ IP của máy
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Lấy đường dẫn các thư mục lưu trữ
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public string GetPathWithRefType(int? RefType)
        {
            switch (RefType)
            {
                case 1:
                    {
                        return "Files/Temp/";
                    }
                default:
                    {
                        return "Files/Temp/";
                    }
            }
        }

        #endregion
    }

}
