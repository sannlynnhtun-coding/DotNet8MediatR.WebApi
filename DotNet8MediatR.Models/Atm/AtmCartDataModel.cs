using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.Atm
{
    [Table("Tbl_AtmCard")]
    public class AtmCartDataModel
    {
        [Key]
        public int CardNumberId { get; set; }

        public string UserName { get; set; } = null!;

        public decimal Balance { get; set; }

        public string CardNumber { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserRoles { get; set; } = null!;
    }
}
