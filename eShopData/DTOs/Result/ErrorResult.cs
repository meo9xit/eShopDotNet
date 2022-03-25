using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.ServiceResult
{
    public class ErrorResult<T> : Result<T>
    {
        public ErrorResult() : base()
        {
            Success = false;
        }

        public ErrorResult(string message) : base(message)
        {
            Success = false;
        }
    }
}
