using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Domain.Entities;

public class Sensor
{
    public int Id { get; private set; }
    public TipoSensor Tipo { get; private set; }
    public StatusSensor Status { get; private set; }
    public string Localizacao { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public DateTime CriadoEm { get; private set; }

    public Sensor(TipoSensor tipo, string localizacao, double latitude, double longitude)
    {
        if (string.IsNullOrWhiteSpace(localizacao)) throw new ArgumentException("Localização é obrigatória.");

        Tipo = tipo;
        Localizacao = localizacao;
        Latitude = latitude;
        Longitude = longitude;
        Status = StatusSensor.Ativo;
        CriadoEm = DateTime.UtcNow;
    }

    public void Ativar() => Status = StatusSensor.Ativo;
    public void Desativar() => Status = StatusSensor.Inativo;
    public void ColocarEmManutencao() => Status = StatusSensor.Manutencao;
}
