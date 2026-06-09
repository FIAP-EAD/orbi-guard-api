using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Enums;
using OrbiGuard.Domain.ValueObjects;

namespace OrbiGuard.Domain.Services;

public class AlertOrchestrator
{
    private readonly RiskAnalyzer _riskAnalyzer;

    public AlertOrchestrator(RiskAnalyzer riskAnalyzer)
    {
        _riskAnalyzer = riskAnalyzer;
    }

    public (Ocorrencia ocorrencia, AlertaInfo alertaInfo)? ProcessarLeitura(Leitura leitura, Sensor sensor)
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

        var nivel = gravidade switch
        {
            GravidadeOcorrencia.Critica => NivelAlerta.Critico,
            GravidadeOcorrencia.Alta    => NivelAlerta.Alto,
            GravidadeOcorrencia.Media   => NivelAlerta.Medio,
            _                           => NivelAlerta.Baixo
        };

        var alertaInfo = new AlertaInfo(
            Mensagem: $"Alerta {nivel}: {tipoOcorrencia} detectado em {sensor.Localizacao}.",
            Nivel: nivel
        );

        return (ocorrencia, alertaInfo);
    }

    private static string GerarDescricao(Sensor sensor, Leitura leitura, GravidadeOcorrencia gravidade) =>
        $"Sensor '{sensor.Tipo}' em '{sensor.Localizacao}' registrou {leitura.Valor} {leitura.Unidade}. Gravidade: {gravidade}.";
}
