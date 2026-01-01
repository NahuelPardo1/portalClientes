using PortalClientes.Domain.Enums;
using PortalClientes.Domain.Exceptions;
namespace PortalClientes.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }
    public string DNI { get; private set; } = null!
    public string PasswordHash { get; private set; } = null!
    public Rol Rol { get; private set; }
    public int? ClienteId { get; private set; } 
    public bool Active { get; private set; }
    public DateTime EntryDate { get; private set; }
    public DateTime? LastAccess { get; private set; }


    protected Usuario() {}

    public Usuario(string dni, string passwordHash, Rol rol, int? clienteId = null)
    {
        if (string.IsNullOrWhiteSpace(dni))
            throw new DomainException("DNI requerido.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("PasswordHash requerido.");

        if (rol == Rol.Cliente && clienteId is null)
            throw new DomainException("Un usuario cliente debe estar asociado a un cliente.");

        if (rol != Rol.Cliente && clienteId is not null)
            throw new DomainException("Solo los usuarios cliente pueden tener ClienteId.");

        Dni = dni.Trim();
        PasswordHash = passwordHash;
        Rol = rol;
        ClienteId = clienteId;
        Active = true;
        EntryDate = DateTime.UtcNow;
        LastAccess = null;
    }

    // Comportamiento de dominio
    public void RegisterAccess()
    {
        LastAccess = DateTime.UtcNow;
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
}
