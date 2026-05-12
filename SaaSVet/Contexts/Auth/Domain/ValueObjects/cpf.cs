namespace SaaSVet.Contexts.Auth.Domain.ValueObjects;

public class cpf
{
    public string value { get; set; }

    public cpf(string value)
    {
        if (value.Length != 11)
            cpfInvalido();
        
        
            
    }

    public void cpfInvalido()
    {
        throw new ArgumentException("CPF inválido");
    }

    public bool verificarJ(string valor)
    { 
        throw new NotImplementedException("Ainda não implementado");
    }

    public bool vreificarK(string valor)
    {
        throw new NotImplementedException("Ainda não implementado");
    }
}