using LKNBll;
using LKNModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LNKIndex.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HeaderNews()
        {
            NewsMsgBll bll = new NewsMsgBll();
            int pageIndex, pageSize, recordCount, pageCount;
            pageIndex = String.IsNullOrEmpty(Request["pageIndex"]) ? 1 : int.Parse(Request["pageIndex"]);
            pageSize = String.IsNullOrEmpty(Request["pageSize"]) ? 3 : int.Parse(Request["pageSize"]);
            List<WorldNews> list = bll.SelectPageMsg(pageIndex, pageSize, 1, out recordCount, out pageCount);
            //分页数据
            string pageStr = PagerHelper.strPage(recordCount, pageSize, pageCount, pageIndex, "/Home/HeaderNews?pageSize=" + pageSize + "&pageIndex=");
            var send = new { list = list, navPage = pageStr };
            return Json(send, JsonRequestBehavior.AllowGet);
                   
           
        }
      
        public ActionResult GuoJiNews()
        {
            NewsMsgBll bll = new NewsMsgBll();
            int pageIndex, pageSize, recordCount, pageCount;
            pageIndex = String.IsNullOrEmpty(Request["pageIndex"]) ? 1 : int.Parse(Request["pageIndex"]);
            pageSize = String.IsNullOrEmpty(Request["pageSize"]) ? 3 : int.Parse(Request["pageSize"]);
            List<WorldNews> list = bll.SelectPageMsg(pageIndex, pageSize, 2, out recordCount, out pageCount);
            //分页数据
            string pageStr = PagerHelper.strPage(recordCount, pageSize, pageCount, pageIndex, "/Home/GuoJiNews?pageSize=" + pageSize + "&pageIndex=");
            var send = new { list = list, navPage = pageStr };
            return Json(send, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GuoNeiNews()
        {
            NewsMsgBll bll = new NewsMsgBll();
            int pageIndex, pageSize, recordCount, pageCount;
            pageIndex = String.IsNullOrEmpty(Request["pageIndex"]) ? 1 : int.Parse(Request["pageIndex"]);
            pageSize = String.IsNullOrEmpty(Request["pageSize"]) ? 3 : int.Parse(Request["pageSize"]);
            List<WorldNews> list = bll.SelectPageMsg(pageIndex, pageSize, 3, out recordCount, out pageCount);
            //分页数据
            string pageStr = PagerHelper.strPage(recordCount, pageSize, pageCount, pageIndex, "/Home/GuoNeiNews?pageSize=" + pageSize + "&pageIndex=");
            var send = new { list = list, navPage = pageStr };
            return Json(send, JsonRequestBehavior.AllowGet);
        }

    }
}
