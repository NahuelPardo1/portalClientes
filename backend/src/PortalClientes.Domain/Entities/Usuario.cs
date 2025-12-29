using PortalClientes.Domain.Enums.Rol;
namespace PortalClientes.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }
    public string DNI { get; private set; }
    public string Password { get; private set; }
    public Rol rol { get; private set; }
    public int? ClienteID { get; private set; }
    public bool Active { get; private set; }
    public DateTime EntryDate { get; private set; }
    public DateTime? LastAccess { get; private set; }


    public Usuario() {}

    public Usuario(string DNI, string Password, Rol rol, int? ClienteID = null, bool active) {
        this.DNI = DNI;
        this.Password = Password;
        this.rol= rol;
        this.ClienteID = ClienteID;
        this.Active = active;
    }
}
