using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.CardHolder
{
    public class CardHolderResponseModel
    {
        public ResponseModel Response { get; set; } = new();
        public int CardNumberId { get; set; }
        public string UserName { get; set; } = null!;
        public decimal Balance { get; set; }
        public string[] UserRoles { get; set; } = null!;
    }
}
