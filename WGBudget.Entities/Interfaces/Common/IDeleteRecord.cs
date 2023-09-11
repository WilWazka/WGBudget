namespace WGBudget.Entities.Interfaces.Common
{
    public interface IDeleteRecord<TData>
    {
        bool Delete(TData data);
    }
}
