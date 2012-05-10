using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
namespace quiz.api
{
    /// <summary>
    ///Inteface <see cref="IUser"/>contains a methods that be implemented
    ///by UserImpl 
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Retrieve user by login and password
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="pwd">Password</param>
        /// <returns>User</returns>
         User GetUserByLoginAndPassword(string login, string pwd);
        /// <summary>
        /// Insert user answer
        /// </summary>
        /// <param name="userId">User identifier</param>
         /// <param name="answerId">Answer identifier</param>
         void AddUserAnswer(int userId, int answerId);
        /// <summary>
        /// Retrieve user answer
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="answerId">Answer identifier</param>
        /// <returns>Answer</returns>
         Answer GetUserAnswer(int userId, int answerId);
    }
}
