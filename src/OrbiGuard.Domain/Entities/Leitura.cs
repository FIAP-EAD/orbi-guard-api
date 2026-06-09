namespace OrbiGuard.Domain.Entities;

public class Leitura
{
    public int Id { get; private set; }
    public int SensorId { get; private set; }
    public double Valor { get; private set; }
    public string Unidade { get; private set; }
    public DateTime DataHora { get; private set; }

    public Leitura(int sensorId, double valor, string unidade, DateTime? dataHora = null)
    {
        if (sensorId <= 0) throw new ArgumentException("SensorId inválido.");
        if (string.IsNullOrWhiteSpace(unidade)) throw new ArgumentException("Unidade é obrigatória.");

        SensorId = sensorId;
        Valor = valor;
        Unidade = unidade;
        DataHora = dataHora ?? DateTime.UtcNow;
    }

    protected Leitura() { Unidade = null!; }
}
