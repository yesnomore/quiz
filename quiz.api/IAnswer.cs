using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
namespace quiz.api
{
    /// <summary>
    ///Inteface <see cref="IAnswer "/>contains a method that be implemented
    ///by AnswerImpl
    /// </summary>
    public interface IAnswer
    {
        /// <summary>
        /// Retun list of answers by question
        /// </summary>
        /// <param name="questionId">Question identifier</param>
        /// <returns>List of answers</returns>
         List<Answer> GetListAnswerByQuestionId(int questionId);
    }
}
