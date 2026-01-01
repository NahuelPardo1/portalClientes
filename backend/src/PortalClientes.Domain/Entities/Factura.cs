public class Factura
{
    public int Id { get; private set; }
    public int ClienteId { get; private set; }
    public string Periodo { get; private set; }
    public DateTime FechaEmision { get; private set; }
    public DateTime FechaVencimientoPago { get; private set; }
    public decimal Total { get; private set; }
    public EstadoFactura Estado { get; private set; }

    // Datos AFIP
    public int? PuntoVenta { get; private set; }
    public int? TipoComprobante { get; private set; }
    public int? NumeroComprobante { get; private set; }
    public string? CAE { get; private set; }
    public DateTime? CAEVencimiento { get; private set; }

    protected Factura() { }

    public Factura(int clienteId, string periodo, DateTime emision, DateTime vencimiento, decimal total)
    {
        ClienteId = clienteId;
        Periodo = periodo;
        FechaEmision = emision;
        FechaVencimientoPago = vencimiento;
        Total = total;
        Estado = EstadoFactura.Pendiente;
    }

    public void MarcarPagada(DateTime fechaPago)
    {
        Estado = EstadoFactura.Pagada;
    }

    public void Anular()
    {
        Estado = EstadoFactura.Anulada;
    }
}
