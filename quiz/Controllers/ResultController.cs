using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quiz.entities;
using quiz.api;
using quiz.core;

namespace quiz.Controllers
{
    /// <summary>
    ///  Controller <see cref="ResultController"/> 
    /// </summary>
    public class ResultController : Controller
    {
        private IResult resultImpl = new ResultImpl();
        private IStat statImpl = new StatImpl();
        /// <summary>
        /// Load the page
        /// </summary>
        /// <returns>Viez</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Return all user answers
        /// </summary>
        /// <returns>Answers</returns>
        public ActionResult ShowResult()
        {
              var user = Session["User"] as User;
              var quiz = Session["Quiz"] as Quiz;
              return (Json(resultImpl.GetResults(user.UserId, quiz.QuizId), JsonRequestBehavior.AllowGet));
        }
        /// <summary>
        /// Return count of user correct anwers
        /// </summary>
        /// <returns>Count of user correct anwers</returns>
        public ActionResult ShowTotal()
        {
            var user = Session["User"] as User;
            var quiz = Session["Quiz"] as Quiz;
            return (Json(statImpl.GetStat(user.UserId, quiz.QuizId), JsonRequestBehavior.AllowGet));
        }
        /// <summary>
        /// Return list of stats for creating chart
        /// </summary>
        /// <returns>Stats</returns>
        public ActionResult ShowStat()
        {
            var quiz = Session["Quiz"] as Quiz;
            return (Json(statImpl.CreateStats(quiz.QuizId), JsonRequestBehavior.AllowGet));
        }
    }
}
