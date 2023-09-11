namespace WGBudget.Entities.Messages.Common
{
    public class PagedList<TData>
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 1;
        public ICollection<TData> Items { get; set; } = Array.Empty<TData>();
    }
}
