
public class ContaBancaria
{
    private double saldo;

    public ContaBancaria()
    {
        this.saldo = 0.0;
    }

    public double Saldo
    {
        get { return saldo; }
    }

    public void Sacar(double valor)
    {
        if (valor <= 0)
        {
            throw new ValorInvalidoException("Valor inválido para saque: " + valor, valor);
        }

        if (valor > saldo)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para saque: " + saldo, saldo);
        }

        saldo -= valor;
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
        {
            throw new ValorInvalidoException("Valor inválido para depósito: " + valor, valor);
        }

        saldo += valor;
    }

    public void Transferir(double valor, ContaBancaria contaDestino)
    {
        Sacar(valor);
        contaDestino.Depositar(valor);
    }
}


public class ValorInvalidoException : Exception
{
    private double valorInvalido;

    public ValorInvalidoException(string mensagem, double valorInvalido)
        : base(mensagem)
    {
        this.valorInvalido = valorInvalido;
    }

    public double ValorInvalido
    {
        get { return valorInvalido; }
    }
}

public class SaldoInsuficienteException : Exception
{
    private double saldoDisponivel;

    public SaldoInsuficienteException(string mensagem, double saldoDisponivel)
        : base(mensagem)
    {
        this.saldoDisponivel = saldoDisponivel;
    }

    public double SaldoDisponivel
    {
        get { return saldoDisponivel; }
    }
}

enum Exercicio  {
    Academia = 1,
    Luta = 2,
    Corrida = 3
}
interface IServico
{
    void Executar();
}

class ServicoFabrica<T> where T : IServico, new(){

     public T NovaInstancia()
    {
        return new T();
    }
}

class ExemploServico : IServico
{
    public void Executar()
    {
        Console.WriteLine("Executando serviço...");
    }
}

struct Ponto<T>
{
    public T X { get; set; }
    public T Y { get; set; }
    public T Z { get; set; }
}

// Estrutura Triangulo com pontos P1, P2 e P3 parametrizados
struct Triangulo<T>
{
    public Ponto<T> P1 { get; set; }
    public Ponto<T> P2 { get; set; }
    public Ponto<T> P3 { get; set; }
}

class Program
{
    static void Main()
    {

        // Exercício 1

        ContaBancaria conta1 = new ContaBancaria();
        ContaBancaria conta2 = new ContaBancaria();

        try
        {
            
            conta1.Depositar(1000);
            conta1.Sacar(500);
            conta1.Transferir(200, conta2);

            
            conta1.Sacar(1500); // Saldo insuficiente
            conta1.Depositar(-100); // Valor inválido
        }
        catch (SaldoInsuficienteException e)
        {
            Console.WriteLine("Erro: " + e.Message + ", Saldo disponível: " + e.SaldoDisponivel);
        }
        catch (ValorInvalidoException e)
        {
            Console.WriteLine("Erro: " + e.Message + ", Valor inválido: " + e.ValorInvalido);
        }

        // Exercício 2
        object o = null;
        try
        {
            o.ToString();
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Ocorreu um erro: Tentativa de chamar o método ToString() em uma referência nula.");
        }

        // Exercício 3
        Console.WriteLine("Opções de exercícios:");
        foreach (Exercicio exercicio in Enum.GetValues(typeof(Exercicio)))
        {
            Console.WriteLine($"{(int)exercicio} - {exercicio}");
        }

        
        Console.Write("Digite o número do exercício desejado (1, 2 ou 3): ");
        int opcao;
        while (!int.TryParse(Console.ReadLine(), out opcao) || !Enum.IsDefined(typeof(Exercicio), opcao))
        {
            Console.WriteLine("Opção inválida. Digite novamente.");
            Console.Write("Digite o número do exercício desejado (1, 2 ou 3): ");
        }

        
        Exercicio exercicioSelecionado = (Exercicio)opcao;
        Console.WriteLine($"Exercício selecionado: {exercicioSelecionado}");

        // Exercício 4
        ServicoFabrica<ExemploServico> fabrica = new ServicoFabrica<ExemploServico>();

        
        ExemploServico servico = fabrica.NovaInstancia();
        servico.Executar();

        // Exercício 5
        Triangulo<int> trianguloInt = new Triangulo<int>
        {
            P1 = new Ponto<int> { X = 1, Y = 2, Z = 3 },
            P2 = new Ponto<int> { X = 4, Y = 5, Z = 6 },
            P3 = new Ponto<int> { X = 7, Y = 8, Z = 9 }
        };

        
        Triangulo<double> trianguloDouble = new Triangulo<double>
        {
            P1 = new Ponto<double> { X = 1.5, Y = 2.5, Z = 3.5 },
            P2 = new Ponto<double> { X = 4.5, Y = 5.5, Z = 6.5 },
            P3 = new Ponto<double> { X = 7.5, Y = 8.5, Z = 9.5 }
        };

        
        Console.WriteLine("Triângulo de inteiros:");
        Console.WriteLine($"P1: {trianguloInt.P1.X}, {trianguloInt.P1.Y}, {trianguloInt.P1.Z}");
        Console.WriteLine($"P2: {trianguloInt.P2.X}, {trianguloInt.P2.Y}, {trianguloInt.P2.Z}");
        Console.WriteLine($"P3: {trianguloInt.P3.X}, {trianguloInt.P3.Y}, {trianguloInt.P3.Z}");

        
        Console.WriteLine("\nTriângulo de doubles:");
        Console.WriteLine($"P1: {trianguloDouble.P1.X}, {trianguloDouble.P1.Y}, {trianguloDouble.P1.Z}");
        Console.WriteLine($"P2: {trianguloDouble.P2.X}, {trianguloDouble.P2.Y}, {trianguloDouble.P2.Z}");
        Console.WriteLine($"P3: {trianguloDouble.P3.X}, {trianguloDouble.P3.Y}, {trianguloDouble.P3.Z}");
    }
}



