namespace MODELS.COMMON
{
    public class CustomException
    {
        public static string ConvertExceptionToMessage(Exception ex, string message)
        {
            return message + " " + ex.Message;
        }
    }
}
