using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.Atm
{
    public static class ChangeModel
    {
        //public static TblAtmCard Change(this CardHolderRequestModel item)
        //{
        //    TblAtmCard model = new TblAtmCard()
        //    {
        //        Balance = item.Balance,
        //        CardNumber = item.CardNumber,
        //        CardNumberId = item.CardNumberId,
        //        FirstName = item.FirstName,
        //        LastName = item.LastName,
        //        Password = item.Password
        //    };
        //    return model;
        //}

        public static string[] GetRoles(this AtmCartDataModel item)
        {
            return item.UserRoles.Split(",").Select(x => x.Trim()).ToArray();
        }
    }
}
