using Omini.Opme.Domain.Common;

namespace Omini.Opme.Api.Dtos;

public sealed record QuotationOutputDto
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid PatientId { get; set; }
    public string PatientName { get; set; }
    public Guid PhysicianId { get; set; }
    public string PhysicianName { get; set; }
    public PayingSourceType PayingSourceType { get; set; }
    public Guid PayingSourceId { get; set; }
    public string PayingSourceName { get; set; }
    public Guid HospitalId { get; set; }
    public string HospitalName { get; set; }
    public Guid InsuranceCompanyId { get; set; }
    public string InsuranceCompanyName { get; set; }
    public Guid InternalSpecialistId { get; set; }
    public string InternalSpecialistName { get; set; }
    public DateTime DueDate { get; set; }
    public List<QuotationOutputItemDto> Items { get; set; }
    public decimal Total { get; set; }

    public sealed record QuotationOutputItemDto
    {
        public int LineId { get; set; }
        public int LineOrder { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string AnvisaCode { get; set; }
        public DateTime AnvisaDueDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public decimal Quantity { get; set; }
    }
}