namespace FamilyBudget.WebApp.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

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

        public List<IE> GetAllIncome(string userId)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Income && ie.UserId == userId).ToList();
        }

        public List<IE> GetAllExpense(string userId)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Expense && ie.UserId == userId).ToList();
        }

        public List<DuplicateIE> GetAllDuplicateIncome(string userId)
        {
            return _db.DuplicateIE.Where(ie => ie.IEType == IEType.Income && ie.UserId == userId).ToList();
        }

        public List<DuplicateIE> GetAllDuplicateExpense(string userId)
        {
            return _db.DuplicateIE.Where(ie => ie.IEType == IEType.Expense && ie.UserId == userId).ToList();
        }

        public IE GetIE(int IeIndex)
        {
            return _db.IE.Where(ie => ie.Id == IeIndex).FirstOrDefault();
        }

        public void RemoveIE(int IeIndex)
        {
            _db.IE.Remove(GetIE(IeIndex));
            _db.SaveChanges();
        }

        public void UpdateIe(int IeIndex, int value, DateTime date)
        {
            var IE = GetIE(IeIndex);
            IE.Value = value;
            IE.Date = date;
            _db.SaveChanges();
        }

        public decimal GetIncomeByMonth(string userId, int month)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Income && ie.UserId == userId && ie.Date.Month == month)
                            .Select(ie => ie.Value)
                            .FirstOrDefault();
        }

        public decimal GetExpenseByMonth(string userId, int month)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Expense && ie.UserId == userId && ie.Date.Month == month)
                                .Select(ie => ie.Value)
                                .FirstOrDefault();
        }

        public decimal GetIncomeByYear(string userId, int year)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Income && ie.UserId == userId && ie.Date.Year == year)
                            .Select(ie => ie.Value)
                            .FirstOrDefault();
        }

        public decimal GetExpenseByYear(string userId, int year)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Expense && ie.UserId == userId && ie.Date.Year == year)
                                .Select(ie => ie.Value)
                                .FirstOrDefault();
        }

        public decimal GetProfitByMonth(string userId, int month)
        {
            return GetIncomeByMonth(userId, month) - GetExpenseByMonth(userId, month);
        }

        public decimal GetProfitForYear(string userId, int year)
        {
            var allIncome = GetIncomeByYear(userId, year) - GetExpenseByYear(userId, year);

            return allIncome;
        }
    }
}