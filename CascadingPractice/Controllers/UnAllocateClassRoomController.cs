using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingPractice.Business_Logic;
using CascadingPractice.Database_Access;

namespace CascadingPractice.Controllers
{
    public class UnAllocateClassRoomController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }

        public void UnAllocateRoomManager()
        {
            UnallocateRoomGateway gateway=new UnallocateRoomGateway();
            gateway.UnallocateRoom();
        }
	}
}