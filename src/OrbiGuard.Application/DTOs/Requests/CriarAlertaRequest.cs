using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Requests;

public record CriarAlertaRequest(int OcorrenciaId, string Mensagem, NivelAlerta Nivel);
