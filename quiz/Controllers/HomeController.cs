using System.Web.Mvc;
using System.Linq;
using quiz.entities;
using quiz.message;
using quiz.api;
using quiz.core;


namespace quiz.Controllers
{
    /// <summary>
    ///  Controller <see cref="HomeController"/> 
    /// </summary>
    public class HomeController : Controller
    {
        private IUser userDaoImpl = new UserImpl();
        /// <summary>
        /// Load the page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Return if the login/password are correct or no
        /// </summary>
        /// <returns>OK or ERROR messages</returns>
        [HttpPost]
        public ActionResult SignIn()
        {
            if (Request.IsAjaxRequest())
            {
                var user = userDaoImpl.GetUserByLoginAndPassword(Request["login"], Request["pwd"]);
                if (user == null)
                {
                    return (Json(Messages.SIGNIN_ERROR));
                }
                Session["User"] = user;
            }
            return (Json(Messages.OK));
        }
        /// <summary>
        /// Read user session
        /// </summary>
        /// <returns>User instance</returns>
        public ActionResult ShowUser()
        {
            var user = Session["User"] as User;
            return (Json(user, JsonRequestBehavior.AllowGet));
        }

    }
}
