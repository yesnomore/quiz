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
    public class AnswerImpl : IAnswer
    {
        private QuizContext _context = new QuizContext();
        /// <summary>
        /// Create new instance of <see cref="AnswerImpl "/> 
        /// </summary>
        public AnswerImpl()
        {
            _context.ContextOptions.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// Retun list of <see cref="Answer"/>
        /// </summary>
        /// <param name="questionId">Question identifier</param>
        /// <returns>List of answers</returns>
        public List<Answer> GetListAnswerByQuestionId(int questionId)
        {
            var answers = _context.Answers.Where(a => a.QuestionId == questionId).ToList();
            return (answers);
        }
       
    }
}
