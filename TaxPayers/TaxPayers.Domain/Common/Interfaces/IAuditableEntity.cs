namespace TaxPayers.Domain.Common.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
