using System.Web;
using System.Web.Mvc;

namespace Test_Case_For_Programmer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
