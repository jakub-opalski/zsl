namespace VehicleFactory.Abstract
{
    public interface IDataStorage<T>
    {
        void Serialize(T obj, string filename);
        T Load(string filename);
    }
}
