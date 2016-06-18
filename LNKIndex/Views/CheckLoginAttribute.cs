using LKNModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNKIndex.Views
{
    public class CheckLoginAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Request.Cookies.Get("loginId")!=null)
            {
                string guid = filterContext.HttpContext.Request.Cookies.Get("loginId").Value;
                if (!string.IsNullOrEmpty(guid))
                {
                    MmHelper m = new MmHelper();
                    string recTxtName = m.Get(guid).ToString();
                    if (!String.IsNullOrEmpty(recTxtName))
                   {
                       m.Set(guid, recTxtName, DateTime.Now.AddMinutes(10));                      
                       return;
                   }                   
                }
            }
            filterContext.HttpContext.Response.Redirect("/Login/Index",true);
            return;
        }
    }
}