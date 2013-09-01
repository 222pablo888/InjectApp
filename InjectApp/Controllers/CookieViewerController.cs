using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InjectApp.Controllers
{
    public class CookieViewerController : Controller
    {

        int loop1, loop2;
        HttpCookieCollection MyCookieColl;
        HttpCookie MyCookie;
        public ActionResult Index()
        {
            MyCookieColl = Request.Cookies;

            // Capture all cookie names into a string array.
            string[] arr1 = MyCookieColl.AllKeys;
            var strBuilder = new StringBuilder();
            // Grab individual cookie objects by cookie name. 
            for (loop1 = 0; loop1 < arr1.Length; loop1++)
            {
                MyCookie = MyCookieColl[arr1[loop1]];
                strBuilder.AppendLine("Cookie: " + MyCookie.Name + "<br>");
                strBuilder.AppendLine("Secure:" + MyCookie.Secure + "<br>");

                //Grab all values for single cookie into an object array.
                String[] arr2 = MyCookie.Values.AllKeys;

                //Loop through cookie Value collection and print all values. 
                for (loop2 = 0; loop2 < arr2.Length; loop2++)
                {
                    strBuilder.AppendLine("Value" + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
                }
            }
            return Content(strBuilder.ToString());
        }
    }
}