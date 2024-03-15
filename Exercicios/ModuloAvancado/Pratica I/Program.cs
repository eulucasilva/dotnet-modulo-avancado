

public class Lampada
{
    private bool ligada;

    public Lampada(bool ligada)
    {
        this.ligada = ligada;
    }

    public void Ligar()
    {
        ligada = true;
    }

    public void Desligar()
    {
        ligada = false;
    }

    public void Imprimir()
    {
        Console.WriteLine(ligada ? "Lâmpada ligada" : "Lâmpada desligada");
    }
}

public class Data
{
    private readonly int dia;
    private readonly int mes;
    private readonly int ano;
    private readonly int hora;
    private readonly int minuto;
    private readonly int segundo;

    public const int FORMATO_12H = 12;
    public const int FORMATO_24H = 24;

    public Data(int dia, int mes, int ano)
    {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    public Data(int dia, int mes, int ano, int hora, int minuto, int segundo) : this(dia, mes, ano)
    {
        this.hora = hora;
        this.minuto = minuto;
        this.segundo = segundo;
    }

    public void Imprimir(int formatoHora)
    {
        string horaFormatada;
        if (formatoHora == FORMATO_12H)
        {
            if (hora < 12)
            {
                horaFormatada = $"{hora:D2}:{minuto:D2}:{segundo:D2} AM";
            }
            else
            {
                horaFormatada = $"{hora - 12:D2}:{minuto:D2}:{segundo:D2} PM";
            }
        }
        else if (formatoHora == FORMATO_24H)
        {
            horaFormatada = $"{hora:D2}:{minuto:D2}:{segundo:D2}";
        }
        else
        {
            throw new ArgumentException("Formato de hora inválido.");
        }

        Console.WriteLine($"{dia:D2}/{mes:D2}/{ano:D4} {horaFormatada}");
    }

    public static void Main()
    {
        Data d1 = new Data(10, 03, 2000, 23, 15, 20);
        d1.Imprimir(Data.FORMATO_12H);
        d1.Imprimir(Data.FORMATO_24H);
    }
}
