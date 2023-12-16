using DotNet8MediatR.Db;
using DotNet8MediatR.Models.Atm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.Login
{
    public class LoginDataAccess
    {
        private readonly AppDbContext _appDbContext;

        public LoginDataAccess(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<LoginResponseModel> Login(string cardNumber, string password)
        {
            LoginResponseModel model = new();
            var item = await _appDbContext.TblAtmCards
                .FirstOrDefaultAsync(x =>
                    x.CardNumber == cardNumber &&
                    x.Password == password);
            if (item is null)
            {
                model.Response.Set(Codes.Success0002);
                goto result;
            }

            model.Response.Set(Codes.Success0001);
            model.UserRoles = item.GetRoles();
            model.Balance = item.Balance;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.UserName = item.UserName;
            model.CardNumber = item.CardNumber;

        result:
            return model;
        }
    }
}
