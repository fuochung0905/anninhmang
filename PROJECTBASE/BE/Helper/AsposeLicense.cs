namespace BE.Helper
{
    public static class License
    {
        public enum AsposeLicenseType
        {
            Word,
            Excel,
            PDF
        }

        public static void SetLicense(AsposeLicenseType licType)
        {
            string LData = "PExpY2Vuc2U+DQo8RGF0YT4NCjxMaWNlbnNlZFRvPktNRCBBL1M8L0xpY2Vuc2VkVG8+DQo8RW1haWxUbz5paXQtc29mdHdhcmVAa21kLmRrPC9FbWFpbFRvPg0KPExpY2Vuc2VUeXBlPlNpdGUgT0VNPC9MaWNlbnNlVHlwZT4NCjxMaWNlbnNlTm90ZT5VcCBUbyAxMCBEZXZlbG9wZXJzIEFuZCBVbmxpbWl0ZWQgRGVwbG95bWVudCBMb2NhdGlvbnM8L0xpY2Vuc2VOb3RlPg0KPE9yZGVySUQ+MjIwODE1MDg1NzQ5PC9PcmRlcklEPg0KPFVzZXJJRD4zMjQwNDU8L1VzZXJJRD4NCjxPRU0+VGhpcyBpcyBhIHJlZGlzdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+DQo8UHJvZHVjdHM+DQo8UHJvZHVjdD5Bc3Bvc2UuVG90YWwgZm9yIC5ORVQ8L1Byb2R1Y3Q+DQo8L1Byb2R1Y3RzPg0KPEVkaXRpb25UeXBlPkVudGVycHJpc2U8L0VkaXRpb25UeXBlPg0KPFNlcmlhbE51bWJlcj5hY2VhNWFmZC0zYzdkLTQwNTItODk5MS1mMWU4NTIyZjYzYjQ8L1NlcmlhbE51bWJlcj4NCjxTdWJzY3JpcHRpb25FeHBpcnk+MjAyMzA4MTg8L1N1YnNjcmlwdGlvbkV4cGlyeT4NCjxMaWNlbnNlVmVyc2lvbj4zLjA8L0xpY2Vuc2VWZXJzaW9uPg0KPExpY2Vuc2VJbnN0cnVjdGlvbnM+aHR0cHM6Ly9wdXJjaGFzZS5hc3Bvc2UuY29tL3BvbGljaWVzL3VzZS1saWNlbnNlPC9MaWNlbnNlSW5zdHJ1Y3Rpb25zPg0KPC9EYXRhPg0KPFNpZ25hdHVyZT5kNkNOeFB6ZG1lbzBJOEVKbWFyVU1SaXpTaXNieGx1T3d6NUJkWUtwcldFeUpicWp2czkzLy9sQ2dQMHROenhJenZuaUQ5VDdQZWZZZUV0bGtRb1ZLVjlmbzNwZGpmaDJRcldGeEpadVJieTl5emZUcUs3QWhnaGo4MVVSRFRwbmV2ZStSQUwzWjYzYndrQ05IMGFuV1IwWjFJNkJkdWc1TDhRWnBkdW9TNWs9PC9TaWduYXR1cmU+DQo8L0xpY2Vuc2U+";
            using (Stream stream = new MemoryStream(Convert.FromBase64String(LData)))
            {
                stream.Seek(0, SeekOrigin.Begin);
                //switch (licType)
                //{
                //    case AsposeLicenseType.Word:
                //        new Aspose.Words.License().SetLicense(stream);
                //        break;
                //    case AsposeLicenseType.Excel:
                //        new Aspose.Cells.License().SetLicense(stream);
                //        break;
                //    case AsposeLicenseType.PDF:
                //        new Aspose.Pdf.License().SetLicense(stream);
                //        break;
                //    default:
                //        break;
                //}
            }
        }
    }
}
