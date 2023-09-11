using System.ComponentModel.DataAnnotations;

namespace WGBudget.Entities.Messages.TransactionCategory
{
    public class TransactionCategoryCreateRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryType { get; set; }
    }
}
