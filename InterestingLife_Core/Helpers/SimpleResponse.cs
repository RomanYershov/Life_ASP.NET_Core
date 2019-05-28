using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestingLife_Core.Helpers
{
    public class SimpleResponse 
    {
        public bool IsSuccess { get; set; }
        public string ErrorText { get; set; }
        public object Data { get; set; }

        public SimpleResponse()
        {
            IsSuccess = true;
        }
        public SimpleResponse(object _data)
        {
            Data = _data;
            IsSuccess = true;
        }

        public SimpleResponse(object _data, bool _isSuccess)
        {
            Data = _data;
            IsSuccess = _isSuccess;
        }

        public SimpleResponse(string errorText)
        {
            ErrorText = errorText;
            IsSuccess = false;
        }
    }
}
