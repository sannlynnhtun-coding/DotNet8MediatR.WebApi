using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.Withdrawal
{
    public class WithdrawalResponseModel
    {
        public ResponseModel Response { get; set; } = new();
        public decimal RecentBalance { get; set; }
        public decimal NewBalance { get; set; }
        public decimal Amount { get; set; }
    }
}
