using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
using quiz.api;


namespace quiz.core
{
    /// <summary>
    /// Class <see cref="ResultImpl "/>  implements <see cref="IResult"/> 
    /// </summary>
    public class ResultImpl:IResult
    {
        private QuizContext _context = new QuizContext();
        private QuestionImpl _questionImpl = new QuestionImpl();
        private AnswerImpl _answerImpl = new AnswerImpl();
        private UserImpl userImpl = new UserImpl();
        /// <summary>
        /// Create new instance of <see cref="ResultImpl "/>
        /// </summary>
        public ResultImpl()
        {
        }
        /// <summary>
        /// Retrieve list of results
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>List of results</returns>
        public List<Result> GetResults(int userId, int quizId)
        {
            List<Question> list = _questionImpl.GetQuestionsByQuizId(quizId);
            List<Result> results = new List<Result>();
            foreach (Question question in list)
            {
                List<Answer> listAnswer = _answerImpl.GetListAnswerByQuestionId(question.QuestionId);
                question.Answers = listAnswer;
                Result result = new Result();
                result.Description = question.Description;
                List<Answer> userAnswers = new List<Answer>();
                foreach (Answer answer in listAnswer)
                {
                    Answer uAnswer = userImpl.GetUserAnswer(userId, answer.AnswerId);
                    var userAnswer = new Answer { AnswerId = answer.AnswerId, Description = answer.Description, IsCorrect = answer.IsCorrect };
                    if (answer.IsCorrect == true)
                    {
                        userAnswer.Message = "(Correct Answer)";
                    }
                    if (uAnswer != null)
                    {
                        userAnswer.IsUserCorrect = true;
                        if (answer.IsCorrect == true)
                        {
                            userAnswer.Message = "(Correct Answer)(Your Answer)";
                        }
                        else
                        {
                            userAnswer.Message = "(Your Answer)";
                        }
                    }
                    userAnswers.Add(userAnswer);
                }
                result.UserAnswers = userAnswers;
                results.Add(result);

            }
            return (results);
        }
    }
}
