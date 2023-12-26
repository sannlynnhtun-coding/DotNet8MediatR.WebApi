using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet8MediatR.Models.Atm;
using DotNet8MediatR.Models.CardHolder;

namespace DotNet8MediatR.Models
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

        public static AtmCartDataModel Change(this CardHolderRequestModel item)
        {
            AtmCartDataModel model = new AtmCartDataModel()
            {
                Balance = item.Balance,
                CardNumber = item.CardNumber,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Password = item.Password,
                UserName = item.UserName,
                UserRoles = item.UserRoles
            };
            return model;
        }
    }
}
