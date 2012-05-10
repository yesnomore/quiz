using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
using quiz.api;

namespace quiz.core
{
    /// <summary>
    /// Class <see cref="AnswerImpl "/>  implements <see cref="IAnswer "/>  
    /// </summary>
    public class UserImpl:IUser
    {
        private QuizContext _context = new QuizContext();
        private QuestionImpl _questionImpl = new QuestionImpl();
        private AnswerImpl _answerImpl = new AnswerImpl();
        /// <summary>
        /// Create new instance of <see cref="AnswerImpl "/> 
        /// </summary>
        public UserImpl()
        {
        }
        /// <summary>
        /// Retrieve user by login and password
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="pwd">Password</param>
        public User GetUserByLoginAndPassword(string login,string pwd)
        {
            var _user = _context.Users.Where(u => u.Login == login && u.Password == pwd).FirstOrDefault();
            if (_user == null) return null;
            var user = new User { UserId = _user.UserId, FirstName = _user.FirstName, LastName = _user.LastName };
            return (user);
        }
        /// <summary>
        /// Insert user answer
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="answerId">Answer identifier</param>
        public void AddUserAnswer(int userId, int answerId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            var answer = _context.Answers.Where(a => a.AnswerId == answerId).FirstOrDefault();
            user.Answers.Add(answer);
            _context.SaveChanges();
        }
        /// <summary>
        /// Retrieve user answer
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="answerId">Answer identifier</param>
        /// <returns>Answer</returns>
        public Answer GetUserAnswer(int userId, int answerId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            var answer = user.Answers.Where(a => a.AnswerId == answerId).FirstOrDefault();
            return (answer);
        }
        
       
    }
}
