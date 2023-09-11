using System.ComponentModel.DataAnnotations;
using WGBudget.Entities.Data;

namespace WGBudget.Entities.Messages.TransactionCategory
{
    public class TransactionCategoryDto
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
