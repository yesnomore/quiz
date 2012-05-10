using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;


namespace quiz.api
{
    /// <summary>
    ///Inteface <see cref="IQuestion "/>contains a methods that be implemented
    ///by AnswerImpl
    /// </summary>
    public interface IQuestion
    {
         /// <summary>
         /// Retrieve list of question identifiers by quiz
         /// </summary>
         /// <param name="quizId">Quiz identifier</param>
         /// <returns>List of question identifiers</returns>
         List<int> GetQuestionIdsByQuizId(int quizId);   
        /// <summary>
         ///  Retrieve question instance by question Identifier
        /// </summary>
        /// <param name="questionId">Question Identifier</param>
        /// <returns>Question</returns>
         Question GetQuestionById(int questionId);    
        /// <summary>
        ///  Retrieve list of questions by quiz Identifier
        /// </summary>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>List of questions</returns>
         List<Question> GetQuestionsByQuizId(int quizId);
    }
}
