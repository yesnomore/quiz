using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
using quiz.api;

namespace quiz.core
{
    /// <summary>
    /// Class <see cref="QuestionImpl "/>  implements <see cref="IQuestion "/> 
    /// </summary>
    public class QuestionImpl : IQuestion
    {
        private QuizContext _context = new QuizContext();
        private AnswerImpl _answerImpl = new AnswerImpl();
        /// <summary>
        /// Create new instance of <see cref="QuestionImpl "/>  
        /// </summary>
        public QuestionImpl()
        {
            _context.ContextOptions.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// Retrieve list of question identifiers by quiz
        /// </summary>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>List of question identifiers</returns>
        public List<int> GetQuestionIdsByQuizId(int quizId)
        {
            var ids = from q in _context.Questions where q.QuizId == quizId select q.QuestionId;
            return (ids.ToList());
        }
        /// <summary>
        ///  Retrieve question instance by question Identifier
        /// </summary>
        /// <param name="questionId">Question Identifier</param>
        /// <returns>Question</returns>
        public Question GetQuestionById(int questionId)
        {
            var question = _context.Questions.Where(q => q.QuestionId == questionId).FirstOrDefault();
            question.Answers = _answerImpl.GetListAnswerByQuestionId(question.QuestionId);
            return (question);
       }
        /// <summary>
        ///  Retrieve list of questions by quiz Identifier
        /// </summary>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>List of questions</returns>
        public List<Question> GetQuestionsByQuizId(int quizId)
        {
            var questions = _context.Questions.Where(q => q.QuizId == quizId);
            return (questions.ToList());
        }        
    }
}
