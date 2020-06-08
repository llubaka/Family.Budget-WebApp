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

        public List<IE> GetIEs(string userId)
        {
            return _db.IE.Where(ie => ie.UserId == userId).ToList();
        }

        public List<DuplicateIE> GetDuplicateIEs(string userId)
        {
            return _db.DuplicateIE.Where(ie => ie.UserId == userId).ToList();
        }

        public List<IE> GetIncomes(string userId)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Income && ie.UserId == userId).ToList();
        }

        public List<IE> GetExpenses(string userId)
        {
            return _db.IE.Where(ie => ie.IEType == IEType.Expense && ie.UserId == userId).ToList();
        }

        public List<DuplicateIE> GetDuplicateIncomes(string userId)
        {
            return _db.DuplicateIE.Where(ie => ie.IEType == IEType.Income && ie.UserId == userId).ToList();
        }

        public List<DuplicateIE> GetDuplicateExpenses(string userId)
        {
            return _db.DuplicateIE.Where(ie => ie.IEType == IEType.Expense && ie.UserId == userId).ToList();
        }

        public IE GetIE(int IeIndex)
        {
            return _db.IE.Where(ie => ie.Id == IeIndex).FirstOrDefault();
        }

        public DuplicateIE GetDuplicateIE(int duplicateIEIndex)
        {
            return _db.DuplicateIE.Where(ie => ie.Id == duplicateIEIndex).FirstOrDefault();
        }

        public void RemoveIE(int IeIndex)
        {
            var ie = GetIE(IeIndex);

            _db.IE.Remove(ie);

            _db.SaveChanges();
        }

        public void RemoveDuplicateIE(int duplicateIndex)
        {
            var duplicateIE = GetDuplicateIE(duplicateIndex);

            _db.DuplicateIE.Remove(duplicateIE);

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