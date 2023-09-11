namespace WGBudget.Entities.Interfaces.Common
{
    public interface IRetrieveRecord<TData, TKey>
    {
        TData GetSingle(TKey id);
        IEnumerable<TData> GetList(IFilter<TData> filter);
    }
}
