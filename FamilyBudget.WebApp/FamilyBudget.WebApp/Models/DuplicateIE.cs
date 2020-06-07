namespace FamilyBudget.WebApp.Models
{
    /// <summary>
    /// Duplicate Income/Expense
    /// </summary>
    public class DuplicateIE
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public int Day { get; set; }

        public IEType IEType { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
         
        public DuplicateIE(string userId, decimal value, int date, IEType ieType)
        {
            this.Value = value;
            this.Day = date;
            this.IEType = ieType;
            this.UserId = userId;
        }
    }
}