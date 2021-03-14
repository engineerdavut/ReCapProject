
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        public bool success { get;  }

        public string message { get; }

        public Result(bool success, string message) : this(success)
        {
            this.message = message;
        }
        public Result(bool success) { 
            this.success = success;
        }
    }
}
