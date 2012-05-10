using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz.entities
{
    /// <summary>
    /// Class <see cref="StatValue "/>  
    /// </summary>
    public class StatValue
    {   
        /// <summary>
        /// User Name
        /// </summary>
        public string Name 
        { 
            get; 
            set; 
        }
        /// <summary>
        /// Count of correct answers
        /// </summary>
        public int Value { 
            get;
            set; 
        }
    }
}
