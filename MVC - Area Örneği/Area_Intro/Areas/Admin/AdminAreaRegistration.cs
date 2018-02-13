using System.Web.Mvc;

namespace Area_Intro.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                //2.Adım olarak new içerisinde Controller eksik burda onu belirtmemiz lazım
                //Controllerımız Home olduğundan area da Home yazdım. Virgülü unutmayın sonrasında !!!
                new {Controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}