using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Responses;

public record AlertaResponse(int Id, int OcorrenciaId, string Mensagem, NivelAlerta Nivel, bool Ativo, DateTime CriadoEm);
