using FamilyBudget.Services.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBudget.Services
{
    public class DbContext : IdentityDbContext, IDbContext
    {
        public void AddExpense(decimal value, IIdentity userId)
        {
            this.AddExpense(value, userId);
        }

        public void AddIncome(decimal value, IIdentity userId)
        {
            this.AddIncome(value, userId);
        }
    }
}
