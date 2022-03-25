using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.ServiceResult
{
    public class Result<T>
    {
        public Result() { }
        public Result(string message)
        {
            Message = message;
        }
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; init; }
    }
}
