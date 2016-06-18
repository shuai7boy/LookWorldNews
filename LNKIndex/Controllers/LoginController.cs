using LKNBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNKIndex.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginCheck()
        {
            string txtUser = Request["txtUser"];
            string txtPwd = Request["txtPwd"];
            if (String.IsNullOrEmpty(txtUser)||String.IsNullOrEmpty(txtPwd))
            {
                Response.Write("输入的数据不能为空");
            }
            else
            {
                //开始校验
                LoginBLL bll = new LoginBLL();
                if(bll.LoginCheck(txtUser, txtPwd))
                {
                    //使用mm校验登陆
                    string guid = Guid.NewGuid().ToString();
                    Response.Cookies.Add(new HttpCookie("loginId", guid));
                    MmHelper m = new MmHelper();
                    m.Set(guid, txtUser, DateTime.Now.AddMinutes(20));
                    Response.Redirect("/BackControl/Index",true);                   
                }
                else
                {
                    Response.Clear();
                    Response.Write("您输入的用户名或密码有误!");
                    Response.End();
                }
            }
            return Content("登陆失败!");
        }

    }
}
