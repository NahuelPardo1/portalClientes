public class Cliente
{
    public int ID { get; private set; }
    public string ClientCode { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public int DNI { get; private set; } = null!;
    public string Mail { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string Adress { get; private set; } = null!;
    public bool Active { get; private set; }
    public DateTime EntryDate { get; private set; }


    protected Cliente() { }

    public Cliente(string ClientCode, string Name, string LastName, int DNI, string Mail, string Phone, string Adress, bool Active = true, DateTime EntryDate) {
        if (string.IsNullOrWhiteSpace(clientCode))
            throw new DomainException("ClientCode es requerido.");

        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name es requerido.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("LastName es requerido.");

        if (string.IsNullOrWhiteSpace(dni))
            throw new DomainException("DNI es requerido.");

        if (dni.Length < 7 || dni.Length > 8 || dni.Any(ch => !char.IsDigit(ch)))
            throw new DomainException("DNI inválido.");

        if (string.IsNullOrWhiteSpace(mail))
            throw new DomainException("Mail es requerido.");

        if (string.IsNullOrWhiteSpace(address))
            throw new DomainException("Address es requerida.");

        ClientCode = clientCode.Trim();
        Name = name.Trim();
        LastName = lastName.Trim();
        Dni = dni.Trim();
        Mail = mail.Trim();
        Phone = phone?.Trim() ?? "";
        Address = address.Trim();
        Active = active;
        EntryDate = entryDate;
    }

    public void Deactivate()
    {
        Active = false;
    }

    public void Activate()
    {
        Active = true;
    }


}