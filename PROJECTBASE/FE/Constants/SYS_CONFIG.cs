using Microsoft.AspNetCore.Mvc.Rendering;
namespace FE.Constants
{
	public class SYS_CONFIG
	{
		public static int[] PAGE_SIZES = new int[] { 10, 20, 30 };
		public const int PAGE_SIZE_DEFAULT = 10;
		public const int PAGE_SIZE_DEFAULT_5 = 5;
		public const int PAGE_SIZE_SHOWLIST = 500;

		public static string PHONGBAN_LABEL = "Phòng ban/khoa";

        public static List<SelectListItem> GIOI_TINH = new List<SelectListItem>()
        {
            new SelectListItem(){Text ="Nam", Value="0"},
            new SelectListItem(){Text ="Nữ", Value="1"},
            new SelectListItem(){Text ="Khác", Value="2"}
        };

		public static List<SelectListItem> TRANG_THAI = new List<SelectListItem>()
		{
			new SelectListItem(){Text ="Hoạt động", Value="True"},
			new SelectListItem(){Text ="Không hoạt động", Value="False"},
		};
    }
}
