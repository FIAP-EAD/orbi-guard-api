using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Domain.ValueObjects;

public record AlertaInfo(string Mensagem, NivelAlerta Nivel);
