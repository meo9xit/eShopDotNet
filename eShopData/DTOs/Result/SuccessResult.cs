using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.ServiceResult
{
    public class SuccessResult<T> : Result<T>
    {
        public SuccessResult() : base()
        {
            Success = true;
        }

        public SuccessResult(string message) : base()
        {
            Success = true;
        }
    }
}
