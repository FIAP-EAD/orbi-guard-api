namespace OrbiGuard.Application.Exceptions;

public class NaoAutorizadoException(string mensagem) : Exception(mensagem);
