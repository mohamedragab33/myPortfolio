namespace Core.Interfaces
{
    public interface IUnitOfWorkRepository<T> where T : class
    {

        IGenricRepository<T> entity { get; }
        void save();

    
    } }
