namespace WGBudget.Entities.Messages.TransactionCategory
{
    public class TransactionCategoryUpdateRequest
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public int TransactionCategoryId { get; set; }
    }
}
