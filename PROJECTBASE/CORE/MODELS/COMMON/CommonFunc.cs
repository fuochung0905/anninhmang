using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using MODELS.BASE;
using System;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MODELS.COMMON
{
    public static class CommonFunc
    {
        public static string GetModelState(ModelStateDictionary dic)
        {
            string error = "";

            var arrError = dic.Select(f => f.Value.Errors).Where(p => p.Count > 0).ToList();
            foreach (var item in arrError)
            {
                error += item[0].ErrorMessage + "<br />";
            }

            return error;
        }

        public static string GetModelStateAPI(ModelStateDictionary modelState)
        {
            var errorList = (from item in modelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();

            return errorList[0];
        }

        public static string GenerateRandomNo()
        {
            int min = 100000;
            int max = 999999;
            Random rdm = new Random();
            return rdm.Next(min, max).ToString();
        }

        public static string GenerateCode(long nextCode)
        {
            var code = DateTime.Now.ToString("yy");
            if (nextCode == 0)
                code += "0000000001";
            else
            {
                if (nextCode < 10) code += "000000000" + nextCode;
                else if (nextCode < 100) code += "00000000" + nextCode;
                else if (nextCode < 1000) code += "0000000" + nextCode;
                else if (nextCode < 10000) code += "000000" + nextCode;
                else if (nextCode < 100000) code += "00000" + nextCode;
                else if (nextCode < 1000000) code += "0000" + nextCode;
                else if (nextCode < 10000000) code += "0000" + nextCode;
                else if (nextCode < 100000000) code += "000" + nextCode;
                else if (nextCode < 1000000000) code += "00" + nextCode;
                else if (nextCode < 10000000000) code += "0" + nextCode;
                else code += nextCode;
            }
            return code;
        }

        public static string ConvertExceptionToMessage(Exception ex, string message)
        {
            return message + " " + ex.Message;
        }

        public static string TrimEx(this string str)
        {
            if (str == null)
            {
                return "";
            }

            return str.Trim();
        }

        public static string RandomString(int length)
        {
            Random rand = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[rand.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        #region CHECK VALIDATE
        public static bool IsValidEmail(string email)
        {
            if (email == null) return false;

            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }


        public static bool IsValidPhone(string phoneNo)
        {
            var phoneNumber = phoneNo.Trim()
                .Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "");
            return Regex.Match(phoneNumber, @"^\d{5,15}$").Success;
        }
        #endregion

        #region EMAIL
        public static void SendMail(IConfiguration _config, string subject, string fromMail, string sender, string toMail, string content)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;

            message.From = new MailAddress(fromMail, sender, System.Text.Encoding.UTF8);
            message.To.Add(toMail);
            message.Subject = subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = content;
            message.BodyEncoding = System.Text.Encoding.UTF8;

            // SMTP
            string SMTP_UserName = "lynx2contact@gmail.com";
            string SMTP_Password = "YgsdFN3t7CsGr2b5";

            SmtpClient smtp = new SmtpClient(_config["MailSettings:Host"], Convert.ToInt32(_config["MailSettings:Port"]));
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;  // SSL 
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(SMTP_UserName, SMTP_Password);

            smtp.Send(message);
        }

        public static bool SendMailNoConfig(string subject, string sender, string toMail, string content, bool isFormatHTML = false)
        {
            try
            {
                string fromMail = "hiday@hidayvn.com";
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;

                message.From = new MailAddress(fromMail, sender, System.Text.Encoding.UTF8);
                message.To.Add(toMail);
                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = isFormatHTML;
                message.Body = content;
                message.BodyEncoding = System.Text.Encoding.UTF8;

                // SMTP
                string SMTP_UserName = fromMail;
                string SMTP_Password = "Lequanghai@123";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;  // SSL 
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(SMTP_UserName, SMTP_Password);

                smtp.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static string SetMailBody(string otpNumber)
        {
            string mailBody = string.Empty;

            mailBody += "<html xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'> ";
            mailBody += "    <head>";
            mailBody += "        <meta charset='UTF-8'> ";
            mailBody += "        <meta http-equiv='X-UA-Compatible' content='IE=edge'>";
            mailBody += "        <meta name='viewport' content='width=device-width, initial-scale=1'>";
            mailBody += "        <title>*|MC:SUBJECT|*</title>";
            mailBody += "        <link href='https://localhost:5186' rel='stylesheet' />";
            mailBody += "</head>";


            return mailBody;
        }
        #endregion

        #region UPLOAD FILE
        public static List<MODELTepDinhKem> UploadData(object lienKetId, string rootPath, string folderName, string tempFolder)
        {
            List<MODELTepDinhKem> result = new List<MODELTepDinhKem>();
            string sourceDirPath = Path.Combine(rootPath, "Files\\Temp\\UploadFile\\" + tempFolder);
            string destinationDirPath = Path.Combine(rootPath, "Files\\" + folderName + "\\" + lienKetId.ToString());
            string relativeDirPath = "Files/" + folderName + "/" + lienKetId.ToString();

            result = SyncUploadFile(sourceDirPath, destinationDirPath, relativeDirPath);

            return result;
        }

        public static List<MODELTepDinhKem> SyncUploadFile(string sourceDirPath, string destinationDirPath, string relativeDirPath = "")
        {
            try
            {
                List<MODELTepDinhKem> lstAttachment = new List<MODELTepDinhKem>();

                //copy file
                if (Directory.Exists(sourceDirPath))
                {
                    string[] arrFiles = Directory.GetFiles(sourceDirPath);
                    if (arrFiles.Count() > 0) //có đính kèm
                    {
                        //Kiểm tra nếu thư mục chưa tồn tại thì tạo mới.
                        if (!Directory.Exists(destinationDirPath))
                        {
                            Directory.CreateDirectory(destinationDirPath);
                        }
                        //Copy file qua thư mục mới
                        foreach (string f in arrFiles)
                        {
                            FileInfo info = new FileInfo(f);
                            //Kiểm tra nếu file tồn tại thì thêm số đánh dấu: file(1).pdf
                            string tempFileName = Path.GetFileNameWithoutExtension(f);
                            //Bỏ ký tự đặc biệt
                            tempFileName = RemoveSign(tempFileName);

                            bool isLoop = true;
                            int counter = 0;
                            while (isLoop)
                            {
                                string tempFileNameWithExtension = tempFileName + info.Extension;
                                string tempFilePath = Path.Combine(destinationDirPath, tempFileNameWithExtension);
                                //Nếu tên file đã tồn tại thì tạo tên file mới.
                                if (File.Exists(tempFilePath))
                                {
                                    counter += 1;
                                    tempFileName = Path.GetFileNameWithoutExtension(f) + "(" + counter.ToString() + ")"; //new name
                                }
                                else
                                    isLoop = false;

                            }
                            //Xác định destFileName   
                            if (counter <= 0)
                            {
                                tempFileName = Path.GetFileNameWithoutExtension(f);
                                //Bỏ ký tự đặc biệt
                                tempFileName = RemoveSign(tempFileName);
                            }

                            string destDirPath = Path.Combine(destinationDirPath, tempFileName + info.Extension);

                            //Copy file
                            if (File.Exists(f))
                            {
                                File.Copy(f, destDirPath, true);
                                //Lấy thông tin file.
                                MODELTepDinhKem tepDinhKem = new MODELTepDinhKem();
                                tepDinhKem.TenFile = tempFileName;
                                tepDinhKem.DoLon = info.Length;
                                tepDinhKem.TenMoRong = info.Extension;
                                tepDinhKem.Url = relativeDirPath + "/" + tepDinhKem.TenFile + tepDinhKem.TenMoRong;

                                lstAttachment.Add(tepDinhKem);
                            }
                        }
                    }
                    //Xóa thư mục tạm.
                    Directory.Delete(sourceDirPath, true);
                }

                return lstAttachment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string RemoveSign(string input)
        {
            string[] strS = { "'", "~", "@", "#", "%", "^", "&", "`", "../", "\\", ":", "*", "?", "<", ">", "|", ",", "-", "+" };
            int iSeek = 0;
            for (int i = 0; i <= strS.Length - 1; i++)
            {
                iSeek = input.IndexOf(strS[i]);
                if (iSeek != -1)
                {
                    input = input.Replace(input.Substring(input.IndexOf(strS[i]), 1), "_");
                }
            }

            return input;
        }
        #endregion

        #region SO SÁNH GIÁ TRỊ 2 OBJECT
        public static bool CompareObject<T> (object A, object B)
        {
            if (A != null && B != null)
            {
                var type = typeof(T);
                var allProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var allSimpleProperties = allProperties.Where(pi => pi.PropertyType.IsSimpleType());
                var unequalProperties =
                       from pi in allSimpleProperties
                       let AValue = type.GetProperty(pi.Name).GetValue(A, null)
                       let BValue = type.GetProperty(pi.Name).GetValue(B, null)
                       where AValue != BValue && (AValue == null || !AValue.Equals(BValue))
                       select pi.Name;
                return unequalProperties.Count() > 0 ? false : true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsSimpleType(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return type.GetGenericArguments()[0].IsSimpleType();
            }
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal));
        }
        #endregion
    }
}
