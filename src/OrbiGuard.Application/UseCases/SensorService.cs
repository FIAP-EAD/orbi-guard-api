using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;
using OrbiGuard.Application.Exceptions;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Application.UseCases;

public class SensorService(ISensorRepository sensorRepo) : ISensorUseCase
{
    public async Task<SensorResponse> CriarAsync(CriarSensorRequest request)
    {
        var sensor = new Sensor(request.Tipo, request.Localizacao, request.Latitude, request.Longitude);
        var salvo = await sensorRepo.SalvarAsync(sensor);
        return ToResponse(salvo);
    }

    public async Task<IEnumerable<SensorResponse>> ObterTodosAsync() =>
        (await sensorRepo.ObterTodosAsync()).Select(ToResponse);

    public async Task<SensorResponse> ObterPorIdAsync(int id)
    {
        var sensor = await sensorRepo.ObterPorIdAsync(id)
            ?? throw new NaoEncontradoException($"Sensor {id} não encontrado.");
        return ToResponse(sensor);
    }

    public async Task DeletarAsync(int id)
    {
        _ = await sensorRepo.ObterPorIdAsync(id)
            ?? throw new NaoEncontradoException($"Sensor {id} não encontrado.");
        await sensorRepo.DeletarAsync(id);
    }

    private static SensorResponse ToResponse(Sensor s) =>
        new(s.Id, s.Tipo, s.Status, s.Localizacao, s.Latitude, s.Longitude);
}
