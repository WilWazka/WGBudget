namespace WGBudget.Entities.Interfaces.Common
{
    public interface IUpdateRecord<TData>
    {
        bool Update(TData data);
    }
}
