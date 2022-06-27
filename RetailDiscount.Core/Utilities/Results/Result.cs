using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool issuccess, string message):this(issuccess)
        {
            IsSuccess = issuccess;
            Message = message;
        }

        public Result(bool issuccess)
        {
            IsSuccess = issuccess;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
