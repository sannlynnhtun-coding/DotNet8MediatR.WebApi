using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.Withdrawal
{
    public class WithdrawalRequestModel
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
