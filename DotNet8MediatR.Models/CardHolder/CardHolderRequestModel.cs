using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.CardHolder
{
    public class CardHolderRequestModel
    {
        public int CardNumberId { get; set; }
        public string? CardNumber { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? UserRoles { get; set; }
        public decimal Balance { get; set; }
    }
}
