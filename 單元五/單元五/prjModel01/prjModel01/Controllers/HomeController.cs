using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjModel01.Models;

namespace prjModel01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // 整數陣列遞減排序
        public string ShowArrayDesc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            string show = "";
            //Linq擴充方法寫法
            var result = score.OrderByDescending(m => m);
            //Linq查詢運算式寫法
            //var result = from m in score
            //             orderby m descending
            //             select m;
            show = "遞減排序：";
            foreach (var m in result)
            {
                show += m + ",";
            }
            show += "<br />";
            show += "總合：" + result.Sum();
            show += "平均：" + result.Average();
            return show;
        }

        //查詢Member會員陣列的帳號與密碼
        public string LoginMember(string uid, string pwd)
        {
            Member[] members = new Member[]
            {
                new Member{ UId="tom", Pwd="123", Name="湯姆"},
                new Member{ UId="jasper", Pwd="456", Name="賈思伯"},
                new Member{ UId="mary", Pwd="789", Name="瑪麗"}
            };
            //Linq查詢運算式寫法
            //Linq擴充方法寫法
            var result = members
                .Where(m => m.UId == uid && m.Pwd == pwd)
                .FirstOrDefault();
            //var result = (from m in members
            //             where m.UId==uid && m.Pwd==pwd
            //             select m).FirstOrDefault();
            string show = "";
            if (result != null)
            {
                show = result.Name + "歡迎進入系統";
            }
            else
            {
                show = "帳號密碼錯誤！";
            }
            return show;
        }


    }
}