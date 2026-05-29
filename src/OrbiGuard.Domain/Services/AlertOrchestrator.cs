using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Domain.Services;

public class AlertOrchestrator
{
    private readonly RiskAnalyzer _riskAnalyzer;

    public AlertOrchestrator(RiskAnalyzer riskAnalyzer)
    {
        _riskAnalyzer = riskAnalyzer;
    }

    public (Ocorrencia ocorrencia, Alerta alerta)? ProcessarLeitura(
        Leitura leitura,
        Sensor sensor)
    {
        if (!_riskAnalyzer.EhCritico(leitura, sensor.Tipo))
            return null;

        var gravidade = _riskAnalyzer.CalcularGravidade(leitura, sensor.Tipo);
        var tipoOcorrencia = _riskAnalyzer.InferirTipoOcorrencia(sensor.Tipo);

        var ocorrencia = new Ocorrencia(
            tipo: tipoOcorrencia,
            gravidade: gravidade,
            localizacao: sensor.Localizacao,
            latitude: sensor.Latitude,
            longitude: sensor.Longitude,
            descricao: GerarDescricao(sensor, leitura, gravidade)
        );

        // A criação do Alerta depende do Id da Ocorrencia ser persistido.
        // O use case é responsável por persistir a Ocorrencia antes de criar o Alerta.
        // Aqui retornamos ambos para o use case coordenar a persistência.
        var alerta = CriarAlerta(ocorrencia, gravidade);

        return (ocorrencia, alerta);
    }

    private static Alerta CriarAlerta(Ocorrencia ocorrencia, GravidadeOcorrencia gravidade)
    {
        var nivel = gravidade switch
        {
            GravidadeOcorrencia.Critica => NivelAlerta.Critico,
            GravidadeOcorrencia.Alta    => NivelAlerta.Alto,
            GravidadeOcorrencia.Media   => NivelAlerta.Medio,
            _                           => NivelAlerta.Baixo
        };

        var mensagem = $"Alerta {nivel}: {ocorrencia.Tipo} detectado em {ocorrencia.Localizacao}.";

        // OcorrenciaId será atribuído pelo use case após persistência.
        return new Alerta(ocorrenciaId: 0, mensagem, nivel);
    }

    private static string GerarDescricao(Sensor sensor, Leitura leitura, GravidadeOcorrencia gravidade) =>
        $"Sensor '{sensor.Tipo}' em '{sensor.Localizacao}' registrou {leitura.Valor} {leitura.Unidade}. Gravidade: {gravidade}.";
}
