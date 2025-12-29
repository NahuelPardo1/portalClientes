public class Cliente
{
    public int ID { get; private set; }
    public string ClientCode { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public int DNI { get; private set; }
    public string Mail { get; private set; }
    public string Phone { get; private set; }
    public string Adress { get; private set; }
    public bool Active { get; private set; }
    public DateTime EntryDate { get; private set; }


    public Cliente() { }

    public Cliente( int ID, string ClientCode, string Name, string LastName, int DNI, string Mail, string Phone, string Adress, bool Active, DateTime EntryDate) { 
        this.ID = ID;
        this.ClientCode = ClientCode;
        this.Name = Name;
        this.LastName = LastName;
        this.DNI = DNI;
        this.Mail = Mail;
        this.Phone = Phone;
        this.Adress = Adress;
        this.Active = Active;
        this.EntryDate = EntryDate;
    }