namespace SaaSVet.Contexts.Register.Domain.ValueObjects;

public class Cpf
{
    public string Value { get; private set; }

    public Cpf()
    {
    }
    public Cpf(string cpf)
    {
        cpf = cpf.Trim().Replace(".", "").Replace("-", "");
        if (cpf.Length != 11) 
            _raiseInvalidCpf();
        
        if (cpf.Distinct().Count() == 1)
            _raiseInvalidCpf();

        // Validar Caracteres
        for (var i = 0; i < 11; i++)
        {
            if (cpf[i] < '0' || cpf[i] > '9')
                _raiseInvalidCpf();
        }

        // Validar Primeiro DV
        var soma = 0;
        for (var i = 0; i < 9; i++)
        {
            soma += (cpf[i] - '0') * (10 - i);
        }
        var resto = soma % 11;
        resto = (resto < 2) ? 0 : 11 - resto;
        if (resto != cpf[9] - '0')
            _raiseInvalidCpf();

        // Validar Segundo DV
        soma = 0;
        for (var i = 0; i < 10; i++)
        {
            soma += (cpf[i] - '0') * (11 - i);
        }
        resto = soma % 11;
        resto = (resto < 2) ? 0 : 11 - resto;
        if (resto != cpf[10] - '0')
            _raiseInvalidCpf();
        
        Value = cpf;
    }

    private void _raiseInvalidCpf()
    {
        throw new ArgumentException("Invalid CPF");
    }
}