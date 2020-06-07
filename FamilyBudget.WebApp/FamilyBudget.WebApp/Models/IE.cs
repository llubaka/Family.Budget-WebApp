namespace FamilyBudget.WebApp.Models
{
    using System;

    /// <summary>
    /// Income/Expense
    /// </summary>
    public class IE
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public IEType IEType { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public IE(string userId, decimal value, DateTime date, IEType ieType)
        {
            this.Value = value;
            this.Date = date;
            this.IEType = ieType;
            this.UserId = userId;
        }
    }
}