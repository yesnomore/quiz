using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using quiz.entities;
using quiz.message;
using quiz.api;
using quiz.core;

namespace quiz.Controllers
{
    /// <summary>
    ///  Controller <see cref="QuestionController"/> 
    /// </summary>
    public class QuestionController : Controller
    {
        private IQuestion questionImpl = new QuestionImpl();
        private IAnswer answerImpl = new AnswerImpl();
        private IUser userImpl = new UserImpl();
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
        /// Return the first question
        /// </summary>
        /// <returns>First question</returns>
        public ActionResult StartQuestion()
        {
            var quiz = Session["Quiz"] as Quiz;
            List<int> QuestionIds=questionImpl.GetQuestionIdsByQuizId(quiz.QuizId);
            Session["QuestionIds"] = QuestionIds;
            Session["QuestionCount"] = QuestionIds.Count;
            Session["QuestionNumber"] = 1;
            return (ListQuestion());
        }
        /// <summary>
        /// Return question
        /// </summary>
        /// <returns>Question</returns>
        public JsonResult ListQuestion()
        {
            List<int> QuestionIds = Session["QuestionIds"] as List<int>;
            if (QuestionIds.Count > 0)
            {
                int id = QuestionIds[0];
                QuestionIds.RemoveAt(0);
                Session["QuestionIds"] = QuestionIds;
                int questionCount = int.Parse(Session["QuestionCount"].ToString()) ;
                int questionNumber = int.Parse(Session["QuestionNumber"].ToString());
                var question=questionImpl.GetQuestionById(id);
                var quest = new { QuestionNumber = questionNumber, QuestionCount = questionCount,Question=question };
                Session["QuestionNumber"] = questionNumber + 1;
                return (Json(quest, JsonRequestBehavior.AllowGet));
            }
            return null;
        }
        /// <summary>
        /// Insert user answer
        /// </summary>
        /// <returns>The next question</returns>
        public ActionResult InsertAnswer()
        {
            List<int> QuestionIds = Session["QuestionIds"] as List<int>;
            var user = Session["User"] as User;
            var quiz = Session["Quiz"] as Quiz;
            if (Request["answerId"] != null)            {
                int answerId = int.Parse(Request["answerId"]);
               
                userImpl.AddUserAnswer(user.UserId, answerId);
                if (QuestionIds.Count>0)
                    return (ListQuestion());        
            }
            statImpl.AddStat(user.UserId, quiz.QuizId);
            return (null);
        }

       
    }
}
