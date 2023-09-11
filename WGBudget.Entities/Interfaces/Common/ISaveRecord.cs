namespace WGBudget.Entities.Interfaces.Common
{
    public interface ISaveRecord<TData, TKey>
    {
        TKey Save(TData data);
    }
}
