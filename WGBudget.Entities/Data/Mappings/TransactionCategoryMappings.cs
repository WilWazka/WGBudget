using WGBudget.Entities.Messages.TransactionCategory;

namespace WGBudget.Entities.Data
{
    public partial class Category
    {
        /// <summary>
        /// Explicit cast from Dto to Entity for <see cref="Transaction"/>.
        /// </summary>
        /// <param name="input"></param>
        public static explicit operator Category(TransactionCategoryDto input)
        {
            if (input == null) return null;

            return new Category
            {
                ID = input.ID ?? 0,
                CategoryType = (CategoryType)input.CategoryType,
                Description = input.Description,
                Name = input.Name,
                CreatedAt = input.CreatedAt,
                ModifiedAt = input.ModifiedAt
            };
        }

        public static explicit operator TransactionCategoryDto(Category input)
        {
            if (input == null) return null;

            return new TransactionCategoryDto
            {
                ID = input.ID,
                CategoryType = (int)input.CategoryType,
                Description = input.Description,
                Name = input.Name,
                CreatedAt = input.CreatedAt,
                ModifiedAt = input.ModifiedAt
            };
        }
    }
}