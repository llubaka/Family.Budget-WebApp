namespace FamilyBudget.WebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Income/Expense
    /// </summary>
    public class IE
    {
        public int Id { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public IEType IEType { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public IE()
        {

        }

        public IE(string userId, decimal value, DateTime date, IEType ieType)
        {
            this.Value = value;
            this.Date = date;
            this.IEType = ieType;
            this.UserId = userId;
        }
    }
}