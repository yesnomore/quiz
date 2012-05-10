using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
namespace quiz.api
{
    /// <summary>
    ///Inteface <see cref="IResult "/>contains a methods that be implemented
    ///by ResultImpl
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Retrieve list of results
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>List of results</returns>
        List<Result> GetResults(int userId, int quizId);       
    }
}
