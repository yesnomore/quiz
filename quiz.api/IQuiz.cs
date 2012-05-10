using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;

namespace quiz.api
{
    /// <summary>
    ///Inteface <see cref="IQuiz "/>contains a methods that be implemented
    ///by QuizImpl
    /// </summary>
    public interface IQuiz
    {    
         /// <summary>
         /// Retrieve all quizs
         /// </summary>
         /// <returns>List of quizs</returns>
         List<Quiz> GetAllQuizs();
        /// <summary>
        /// Retrieve all quizs
        /// </summary>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>Quiz</returns>
         Quiz GetQuizById(int quizId);       
    }
}
