namespace api.Data.Common
{
    public interface IDeletableEntity : IEntity
    {
        DateTime? DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
