using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz.entities
{
    /// <summary>
    /// Class <see cref="Result "/>  
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Question description
        /// </summary>
        public  string Description
        {
            get;
            set;
        }
        /// <summary>
        /// List of user answers
        /// </summary>
        public List<Answer> UserAnswers
        {
            get;
            set;
        }
       
    }
}
