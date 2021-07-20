using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BT_Lab04.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BT_Lab04.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BigSchoolContext context = new BigSchoolContext();
            var upcommingCourse = context.Courses.Where(p => p.DateTime >
           DateTime.Now).OrderBy(p => p.DateTime).ToList();
            
            var userID = User.Identity.GetUserId();
            foreach (Course i in upcommingCourse)
            {
                
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.LecturerId);
                i.Name = user.Name;
                //lấy ds tham gia khóa học
                if (userID != null)
                {
                    i.isLogin = true;
                    //ktra user đó chưa tham gia khóa học
                    Attendance find = context.Attendances.FirstOrDefault(p =>p.CourseId == i.Id && p.Attendee == userID);
                    if (find == null)
                        i.isShowGoing = true;
                    //ktra user đã theo dõi giảng viên của khóa học ?
                    Following findFollow = context.Followings.FirstOrDefault(p =>p.FollowerId == userID && p.FolloweeId == i.LecturerId);
                    if (findFollow == null)
                        i.isShowFollow = true;
                }
            }
            return View(upcommingCourse);
        }


    }
}