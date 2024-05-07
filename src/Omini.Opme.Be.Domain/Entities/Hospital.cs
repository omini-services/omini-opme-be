namespace Omini.Opme.Be.Domain.Entities;

public class Hospital : Auditable
{
    public CompanyName Name { get; set; }
    public string Cnpj { get; set; }
    public string Comments { get; set; }
}