using System.Web.Mvc;

namespace TestUngDung.Areas.BANHANGGROUP
{
    public class BANHANGGROUPAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BANHANGGROUP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BANHANGGROUP_default",
                "BANHANGGROUP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}