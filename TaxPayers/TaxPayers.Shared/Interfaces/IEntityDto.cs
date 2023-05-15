namespace TaxPayers.Shared.Interfaces
{
    public interface IEntityDto : IEntityDto<int>
    {

    }

    public interface IEntityDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
