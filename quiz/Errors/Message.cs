using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz.message
{
    public class Message
    {
        public Message(string key, string message)
        {
            this.key = key;
            this.message = message;
        }
        public string key { get; set; }
        public string message { get; set; }
    }
}
