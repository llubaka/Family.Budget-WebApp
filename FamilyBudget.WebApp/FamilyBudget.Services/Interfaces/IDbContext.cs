namespace FamilyBudget.Services.Interfaces
{
    using System;

    public interface IDbContext
    {
        void AddIncome(decimal value, System.Security.Principal.IIdentity userId);

        void AddExpense(decimal value, System.Security.Principal.IIdentity userId);
    }
}
