using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz.message
{
    public class Messages
    {
        public static Message OK = new Message("OK", "");
        public static Message EXIST = new Message("EXIST", "");
        public static Message SIGNIN_ERROR = new Message("KO", "The username or password you entered is incorrect");
    }
}
