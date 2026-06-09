using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Domain.Entities;

public class Alerta
{
    public int Id { get; private set; }
    public int OcorrenciaId { get; private set; }
    public string Mensagem { get; private set; }
    public NivelAlerta Nivel { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }

    public Alerta(int ocorrenciaId, string mensagem, NivelAlerta nivel)
    {
        if (ocorrenciaId <= 0) throw new ArgumentException("OcorrenciaId inválido.");
        if (string.IsNullOrWhiteSpace(mensagem)) throw new ArgumentException("Mensagem é obrigatória.");

        OcorrenciaId = ocorrenciaId;
        Mensagem = mensagem;
        Nivel = nivel;
        Ativo = true;
        CriadoEm = DateTime.UtcNow;
    }

    protected Alerta() { Mensagem = null!; }

    public void Desativar() => Ativo = false;
}
