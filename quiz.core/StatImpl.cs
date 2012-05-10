using System.Collections.Generic;
using System.Linq;
using quiz.entities;
using quiz.api;
namespace quiz.core
{
    /// <summary>
    /// Class <see cref="StatImpl "/>  implements <see cref="IStat"/> 
    /// </summary>
    public class StatImpl:IStat
    {
        private QuizContext _context = new QuizContext();
        private QuestionImpl _questionImpl = new QuestionImpl();
        private AnswerImpl _answerImpl = new AnswerImpl();
        private UserImpl _userImpl = new UserImpl();
        /// <summary>
        /// Create new instance of <see cref="StatImpl "/>
        /// </summary>
        public StatImpl()
        {

        }      
        private int CreateStat(int userId, int quizId)
        {
         
            List<Question> list = _questionImpl.GetQuestionsByQuizId(quizId);
            int correctAnswers = 0;
            foreach (Question question in list)
            {
                List<Answer> listAnswer = _answerImpl.GetListAnswerByQuestionId(question.QuestionId);

                foreach (Answer answer in listAnswer)
                {
                    Answer uAnswer = _userImpl.GetUserAnswer(userId, answer.AnswerId);
                    if (uAnswer != null)
                    {
                        if (answer.IsCorrect == true)
                        {
                            correctAnswers++;
                        }                        
                    }
                }      
            }
            return (correctAnswers);
        }
        /// <summary>
        /// Insert Stat
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="quizId">Quiz identifier</param>
        public void AddStat(int userId, int quizId)
        {
            Stat stat = new Stat();
            stat.Users_UserId=  userId ;
            stat.Quizs_QuizId  = quizId ;
            stat.CorrectAnswers = CreateStat(userId, quizId);
            _context.Stats.AddObject(stat);
            _context.SaveChanges();
        }
        /// <summary>
        /// Retrieve stat
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>Stat</returns>
        public Stat GetStat(int userId, int quizId)
        {
            var stat = _context.Stats.Where(s => s.User.UserId == userId && s.Quiz.QuizId == quizId).FirstOrDefault();
            if (stat==null) return null;
            return (new Stat { CorrectAnswers = stat.CorrectAnswers });
        }
        /// <summary>
        /// Create stats values used by graphic charts
        /// </summary>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>List of stat values</returns>
        public List<StatValue> CreateStats(int quizId)
        {
            var stat = from s in _context.Stats where s.Quiz.QuizId == quizId
                        orderby s.CorrectAnswers descending
                        select s;
            List<StatValue> stats = new List<StatValue>();
            foreach(Stat s in stat.Take(10).ToList())
            {
                stats.Add(new StatValue { Name=s.User.FirstName, Value=s.CorrectAnswers});
            }
            return (stats);
        }
    }
}
