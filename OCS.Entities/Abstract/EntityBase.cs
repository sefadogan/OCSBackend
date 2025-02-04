namespace OCS.Entities.Abstract
{
    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
