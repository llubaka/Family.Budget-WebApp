namespace FamilyBudget.Services
{
    using System;
     
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Service
    {
        private readonly DbContext db;

        public Service(DbContext db)
        {
            this.db = db;
        }

        public void AddIncome(decimal value, System.Security.Principal.IIdentity userId )
        {
            db.AddIncome(value, userId);
        }

        public void AddExpense(decimal value, System.Security.Principal.IIdentity userId )
        {
            db.AddExpense(value, userId);
        }
    }
}
