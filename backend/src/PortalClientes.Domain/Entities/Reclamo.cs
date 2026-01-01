using PortalClientes.Domain.Enums;
using PortalClientes.Domain.Exceptions;

namespace PortalClientes.Domain.Entities;

public class Reclamo
{
    public int Id { get; private set; }
    public int ClienteId { get; private set; }

    public string? Titulo { get; private set; }
    public string Descripcion { get; private set; } = null!;

    public CategoriaReclamo Categoria { get; private set; }
    public PrioridadReclamo Prioridad { get; private set; }
    public EstadoReclamo Estado { get; private set; }

    public int? AsignadoAUsuarioId { get; private set; }

    public DateTime CreadoEn { get; private set; }
    public DateTime ActualizadoEn { get; private set; }

    // Para EF
    protected Reclamo() { }

    public Reclamo(
        int clienteId,
        string descripcion,
        CategoriaReclamo categoria,
        Prioridad prioridad,
        string? titulo = null)
    {
        if (clienteId <= 0)
            throw new DomainException("ClienteId inválido.");

        if (string.IsNullOrWhiteSpace(descripcion))
            throw new DomainException("La descripción del reclamo es requerida.");

        ClienteId = clienteId;
        Descripcion = descripcion.Trim();
        Titulo = string.IsNullOrWhiteSpace(titulo) ? null : titulo.Trim();
        Categoria = categoria;
        Prioridad = prioridad;

        Estado = EstadoReclamo.Nuevo;
        CreadoEn = DateTime.UtcNow;
        ActualizadoEn = CreadoEn;
    }

    public void AsignarA(int usuarioId)
    {
        if (usuarioId <= 0)
            throw new DomainException("Usuario asignado inválido.");

        AsignadoAUsuarioId = usuarioId;
        Touch();
    }

    public void Desasignar()
    {
        AsignadoAUsuarioId = null;
        Touch();
    }

    public void CambiarEstado(EstadoReclamo nuevoEstado)
    {
        if (nuevoEstado == Estado)
            return;

        if (!EsTransicionValida(Estado, nuevoEstado))
            throw new DomainException($"Transición de estado inválida: {Estado} -> {nuevoEstado}.");

        Estado = nuevoEstado;
        Touch();
    }

    private static bool EsTransicionValida(EstadoReclamo actual, EstadoReclamo nuevo)
    {
        // Reglas simples (MVP):
        // Nuevo -> EnProgreso | Cerrado
        // EnProgreso -> Resuelto | Cerrado
        // Resuelto -> Cerrado | Reabierto
        // Cerrado -> Reabierto
        // Reabierto -> EnProgreso | Cerrado
        return actual switch
        {
            EstadoReclamo.Nuevo => nuevo is EstadoReclamo.EnProgreso or EstadoReclamo.Cerrado,
            EstadoReclamo.EnProgreso => nuevo is EstadoReclamo.Resuelto or EstadoReclamo.Cerrado,
            EstadoReclamo.Resuelto => nuevo is EstadoReclamo.Cerrado or EstadoReclamo.Reabierto,
            EstadoReclamo.Cerrado => nuevo is EstadoReclamo.Reabierto,
            EstadoReclamo.Reabierto => nuevo is EstadoReclamo.EnProgreso or EstadoReclamo.Cerrado,
            _ => false
        };
    }

    private void Touch() => ActualizadoEn = DateTime.UtcNow;
}
