using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Domain.Entities;

public class Ocorrencia
{
    public int Id { get; private set; }
    public TipoOcorrencia Tipo { get; private set; }
    public GravidadeOcorrencia Gravidade { get; private set; }
    public StatusOcorrencia Status { get; private set; }
    public string Localizacao { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataHora { get; private set; }

    public Ocorrencia(
        TipoOcorrencia tipo,
        GravidadeOcorrencia gravidade,
        string localizacao,
        double latitude,
        double longitude,
        string descricao)
    {
        if (string.IsNullOrWhiteSpace(localizacao)) throw new ArgumentException("Localização é obrigatória.");
        if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentException("Descrição é obrigatória.");

        Tipo = tipo;
        Gravidade = gravidade;
        Localizacao = localizacao;
        Latitude = latitude;
        Longitude = longitude;
        Descricao = descricao;
        Status = StatusOcorrencia.Aberta;
        DataHora = DateTime.UtcNow;
    }

    protected Ocorrencia() { Localizacao = null!; Descricao = null!; }

    public void IniciarAtendimento()
    {
        if (Status != StatusOcorrencia.Aberta)
            throw new InvalidOperationException("Apenas ocorrências abertas podem ser atendidas.");
        Status = StatusOcorrencia.EmAtendimento;
    }

    public void Resolver()
    {
        if (Status == StatusOcorrencia.Resolvida || Status == StatusOcorrencia.Cancelada)
            throw new InvalidOperationException("Ocorrência já encerrada.");
        Status = StatusOcorrencia.Resolvida;
    }

    public void Cancelar()
    {
        if (Status == StatusOcorrencia.Resolvida || Status == StatusOcorrencia.Cancelada)
            throw new InvalidOperationException("Ocorrência já encerrada.");
        Status = StatusOcorrencia.Cancelada;
    }
}
