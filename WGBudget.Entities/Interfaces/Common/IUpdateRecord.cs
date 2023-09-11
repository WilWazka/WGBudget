namespace WGBudget.Entities.Interfaces.Common
{
    public interface IUpdateRecord<TData>
    {
        void Update(TData data);
    }
}
