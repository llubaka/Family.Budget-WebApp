namespace FamilyBudget.WebApp.Services
{
    using System;

    using FamilyBudget.WebApp.Models;

    public class Service
    {
        private ApplicationDbContext _db;

        public Service(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void AddIE(string userId, decimal value, DateTime date, IEType ieType)
        {
            _db.IE.Add(new IE(userId, value, date, ieType));

            _db.SaveChanges();
        }

        public void AddDuplicateIE(string userId, decimal value, int day, IEType ieType)
        {
            _db.DuplicateIE.Add(new DuplicateIE(userId, value, day, ieType));

            _db.SaveChanges();
        }

        //TODO: Taka all incomes , dI

        //TODO: Take all expenses , dE

        //remove , update , delete 

        //TODO: Get Income for spec. month

        //TODO: Get Expense for spec. month

        //TODO: Get dohod for spec. month
    }
}