namespace OrbiGuard.Domain.Entities;

public class Abrigo
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public int Capacidade { get; private set; }
    public int OcupacaoAtual { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    public bool Disponivel => OcupacaoAtual < Capacidade;
    public int VagasDisponiveis => Capacidade - OcupacaoAtual;

    public Abrigo(string nome, int capacidade, double latitude, double longitude)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome é obrigatório.");
        if (capacidade <= 0) throw new ArgumentException("Capacidade deve ser maior que zero.");

        Nome = nome;
        Capacidade = capacidade;
        OcupacaoAtual = 0;
        Latitude = latitude;
        Longitude = longitude;
    }

    protected Abrigo() { Nome = null!; }

    public void AtualizarOcupacao(int novaOcupacao)
    {
        if (novaOcupacao < 0) throw new ArgumentException("Ocupação não pode ser negativa.");
        if (novaOcupacao > Capacidade) throw new InvalidOperationException("Ocupação excede a capacidade do abrigo.");
        OcupacaoAtual = novaOcupacao;
    }
}
