using LKNBll;
using LKNModel;
using LNKIndex.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNKIndex.Controllers
{
     [CheckLogin]
    public class BackControlController : Controller
    {        //
        // GET: /BackControl/
     
        public ActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Control(FormCollection collection)
        {
            string title = Request["title"];
            string author = Request["author"];
            DateTime time = DateTime.Now;
            string imgUrl = "/Files/1.jpg";
            string content = Request["html"];
            content = Server.UrlDecode(content);
            string keyWord = "/Content/kindeditor-4.1.10/";
            int index = 0;
            List<int> list=new List<int>();
            while ((index=content.IndexOf(keyWord,index))!=-1)
            {
                list.Add(index);
                index = index + keyWord.Length;
            }
            if (list!=null)
            {
                foreach (var item in list)
                {
                    content = content.Insert(item, "..");
                }
            }
            string biaoshi = Request["control"];
            string detailUrl=null;
            //详情页
            string[] param = new string[5];
            param[0] = title;
            param[1] = author;
            param[2] = content;
            param[3] = time.ToString();
            param[4] = imgUrl;
            htmlWeb.CreateHtm cs = new htmlWeb.CreateHtm();
            detailUrl = cs.MakeHtml(@"G:\代码存放\ASP.NET代码存放\LookWorldNews\LNKIndex\config.xml", "article", @"G:\代码存放\ASP.NET代码存放\LookWorldNews\LNKIndex\Test\", @"G:\代码存放\ASP.NET代码存放\LookWorldNews\LNKIndex\templete.htm", param);
            //将数据保存到数据库里面
            WorldNews w = new WorldNews();
            w.Title = title;
            w.Author = author;
            w.SendTime = time;
            w.ImgUrl = imgUrl;
            w.Content = content;
            w.DetailUrl = detailUrl;
            w.BiaoShi = int.Parse(biaoshi);
            NewsMsgBll bll = new NewsMsgBll();
            if(bll.Add(w))
            {
                return Content("1");
            }            
            return Content("提交失败!");
        }
      
    }
}
