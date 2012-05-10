using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quiz.entities;
using quiz.api;
using quiz.core;
using quiz.message;

namespace quiz.Controllers
{
    /// <summary>
    ///  Controller <see cref="QuizController"/> 
    /// </summary>
    public class QuizController : Controller
    {
        private IQuiz quizImpl = new QuizImpl();
        private IStat statImpl = new StatImpl();
        /// <summary>
        /// Load the page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Return list of quizs
        /// </summary>
        /// <returns>Quizs</returns>
        public ActionResult ListQuiz()
        {
            return (Json(quizImpl.GetAllQuizs(),JsonRequestBehavior.AllowGet));
        }
        /// <summary>
        /// Select one quiz
        /// </summary>
        /// <returns>Quiz</returns>
        public ActionResult SelectQuiz()
        {
            if (Request.IsAjaxRequest())
            {
                int quizId = int.Parse(Request["quizId"]);
                var quiz = quizImpl.GetQuizById(quizId);
                Session["Quiz"] = quiz;
                var user = Session["User"] as User;
                var stat = statImpl.GetStat(user.UserId,quizId);
                if(stat!=null)
                    return (Json(Messages.EXIST));
            }

           return (Json(Messages.OK));
        }
        /// <summary>
        /// Read quiz session
        /// </summary>
        /// <returns>Quiz</returns>
        public ActionResult ShowQuiz()
        {
            var quiz = Session["Quiz"] as Quiz;
            return (Json(quiz, JsonRequestBehavior.AllowGet));
        }
    }
}
