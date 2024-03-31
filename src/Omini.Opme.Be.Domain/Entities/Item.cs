using Omini.Opme.Be.Shared.Entities;

namespace Omini.Opme.Be.Domain.Entities;

public class Item : Auditable
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? SalesName { get; set; }
    public string Description { get; set; }
    public string? Uom { get; set; }
    public string? AnvisaCode { get; set; }
    public DateTime? AnvisaDueDate { get; set; }
    public string? SupplierCode { get; set; }
    public string? Cst { get; set; }
    public string? SusCode { get; set; }
    public string? NcmCode { get; set; }    
}