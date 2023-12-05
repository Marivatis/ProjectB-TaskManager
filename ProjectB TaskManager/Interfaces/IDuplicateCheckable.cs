
namespace ProjectB_TaskManager.Interfaces
{
    public interface IDuplicateCheckable<T>
    {
        bool IsDuplicate(T item);
    }
}