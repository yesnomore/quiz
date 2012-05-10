using System.Collections.Generic;
using System.Linq;
using quiz.entities;
namespace quiz.api
{
    /// <summary>
    ///Inteface <see cref="IStat "/>contains a methods that be implemented
    ///by StatImpl
    /// </summary>
    public interface IStat
    {         
        /// <summary>
        /// Insert Stat
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="quizId">Quiz identifier</param>
         void AddStat(int userId, int quizId);
        /// <summary>
        /// Retrieve stat
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>Stat</returns>
         Stat GetStat(int userId, int quizId);
        /// <summary>
        /// Create stats values used by graphic charts
        /// </summary>
        /// <param name="quizId">Quiz identifier</param>
        /// <returns>List of stat values</returns>
         List<StatValue> CreateStats(int quizId);       
    }
}
