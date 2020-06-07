namespace FamilyBudget.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Duplicate Income/Expense
    /// </summary>
    public class DuplicateIE
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public int Day { get; set; }

        [Required]
        public IEType IEType { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DuplicateIE()
        {

        }

        public DuplicateIE(string userId, decimal value, int date, IEType ieType)
        {
            this.Value = value;
            this.Day = date;
            this.IEType = ieType;
            this.UserId = userId;
        }
    }
}