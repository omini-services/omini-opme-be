using Omini.Opme.Domain.Common;

namespace Omini.Opme.Api.Dtos;

public sealed record QuotationOutputDto
{
    public Guid Id { get; set; }
    public long Number { get; set; }
    public DateTime CreatedOn { get; set; }
    public string PatientCode { get; set; }
    public string PatientFirstName { get; set; }
    public string PatientMiddleName { get; set; }
    public string PatientLastName { get; set; }
    public string PhysicianCode { get; set; }
    public string PhysicianFirstName { get; set; }
    public string PhysicianMiddleName { get; set; }
    public string PhysicianLastName { get; set; }
    public PayingSourceType PayingSourceType { get; set; }
    public string HospitalCode { get; set; }
    public string HospitalName { get; set; }
    public string InsuranceCompanyCode { get; set; }
    public string InsuranceCompanyName { get; set; }
    public string InternalSpecialistCode { get; set; }
    public string InternalSpecialistName { get; set; }
    public DateTime DueDate { get; set; }
    public List<QuotationItemOutputDto> Items { get; set; }
    public double Total { get; set; }
    public string Comments { get; set; }

    public sealed record QuotationItemOutputDto
    {
        public int LineId { get; set; }
        public int LineOrder { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string AnvisaCode { get; set; }
        public DateTime AnvisaDueDate { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal { get; set; }
        public double Quantity { get; set; }
    }
}