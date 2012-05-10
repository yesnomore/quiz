using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
using quiz.api;


namespace quiz.core
{
    /// <summary>
    /// Class <see cref="QuizImpl "/>  implements <see cref="IQuiz"/> 
    /// </summary>
    public class QuizImpl : IQuiz
    {
        private QuizContext _context = new QuizContext();
        /// <summary>
        /// Create new instance of <see cref="QuizImpl "/>
        /// </summary>
        public QuizImpl()
        {
            _context.ContextOptions.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// Retrieve all quizs
        /// </summary>
        /// <returns>List of quizs</returns>
        public List<Quiz> GetAllQuizs()
        {
            var quizs = _context.Quizs.ToList();
            return (quizs);
        }
        /// <summary>
        /// Retrieve all quizs
        /// </summary>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>Quiz</returns>
        public Quiz GetQuizById(int id)
        {
            var quiz = _context.Quizs.Where(q => q.QuizId == id).FirstOrDefault();
            return (quiz);
        }
    }
}
