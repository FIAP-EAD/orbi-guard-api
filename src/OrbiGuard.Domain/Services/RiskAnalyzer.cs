using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Domain.Services;

public class RiskAnalyzer
{
    private static readonly Dictionary<TipoSensor, double> Limites = new()
    {
        { TipoSensor.NivelAgua,   80.0  },
        { TipoSensor.Fumaca,      50.0  },
        { TipoSensor.Temperatura, 45.0  },
        { TipoSensor.QualidadeAr, 150.0 },
        { TipoSensor.Umidade,     95.0  }
    };

    public bool EhCritico(Leitura leitura, TipoSensor tipoSensor)
    {
        return Limites.TryGetValue(tipoSensor, out var limite) && leitura.Valor >= limite;
    }

    public GravidadeOcorrencia CalcularGravidade(Leitura leitura, TipoSensor tipoSensor)
    {
        if (!Limites.TryGetValue(tipoSensor, out var limite))
            return GravidadeOcorrencia.Baixa;

        var proporcao = leitura.Valor / limite;

        return proporcao switch
        {
            >= 1.5 => GravidadeOcorrencia.Critica,
            >= 1.2 => GravidadeOcorrencia.Alta,
            >= 1.0 => GravidadeOcorrencia.Media,
            _      => GravidadeOcorrencia.Baixa
        };
    }

    public TipoOcorrencia InferirTipoOcorrencia(TipoSensor tipoSensor) => tipoSensor switch
    {
        TipoSensor.NivelAgua   => TipoOcorrencia.Alagamento,
        TipoSensor.Fumaca      => TipoOcorrencia.Incendio,
        TipoSensor.Temperatura => TipoOcorrencia.CalorExtremo,
        TipoSensor.QualidadeAr => TipoOcorrencia.CalorExtremo,
        TipoSensor.Umidade     => TipoOcorrencia.Deslizamento,
        _                      => TipoOcorrencia.Alagamento
    };
}
