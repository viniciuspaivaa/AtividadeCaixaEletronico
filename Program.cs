using System.Net;
using System.Diagnostics.Contracts;

class Extrato
{
    public string Tipo {get; set;}
    public float Valor {get; set;}
    public string DataHora {get; set;}

    public Extrato( string tipo, float valor)
    {
        Tipo = tipo;
        Valor = valor;
        DataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }

    public void Movimentos()
    {
        Console.WriteLine($"{Tipo.PadRight(14)}R$ {(Valor).ToString("F2").PadRight(11)}{DataHora}");
    }
}

class Program
{
    public static float Validacao(string msg)
    {
        float valido;

        Console.Write(msg);
        while(!float.TryParse(Console.ReadLine(), out valido) || valido < 0)
        {
            Console.Write("Número Inválido! Tente novamente: ");
        }

        return valido;
    }

    static void Main(string[] args)
    {
        int opcao;
        float saldo = 0;
        float limite = 0;
        List<Extrato> extrato = new List<Extrato>();
        bool contaCorrente = true;

        Console.Clear();
        Console.WriteLine("=".PadLeft(19, '='));
        Console.WriteLine("Bem-vindo ao caixa!");
        Console.WriteLine("=".PadLeft(19, '='));

        do
        {
            Console.Write("1. Verificar saldo\n2. Tipo de conta\n3. Limite da conta\n4. Saque\n5. Depósito\n6. Extrato\n7. Transferência\n0. Sair\nDigite a opção desejada: ");
            while(!int.TryParse(Console.ReadLine(), out opcao)){Console.Write("Número inválido! Tente novamente: ");}

            switch(opcao)
            {
                case 1: //Verificar saldo
                    Console.Clear();
                    Console.WriteLine($"Seu saldo na conta é R${saldo:F2}!\n");
                    break;

                case 2: //Tipo de conta
                    Console.Clear();
                    string tipoConta = contaCorrente ? "corrente" : "poupança";
                    Console.WriteLine($"O tipo da sua conta é {tipoConta}!\n");
                    break;

                case 3: //Limite da conta
                    Console.WriteLine($"O limite da conta atual é R${limite:F2}, pressione Enter para adicionar um novo limite ou pressione outra tecla para sair...");

                    var key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.Enter)
                    {
                        limite = Validacao("Digite o novo saldo: ");
                        Console.Clear();
                        Console.WriteLine("Novo limite adicionado!\n");
                    }
                    else
                    {
                        Console.Clear();
                    }
                    break;

                case 4: //Saque
                    if(saldo <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Saldo insuficiente!\n");
                    }
                    else
                    {
                        float saque = Validacao("Digite o valor do saque: ");
                        saldo -= saque;
                        extrato.Add(new Extrato("Saque", saque));
                        Console.Clear();
                        Console.WriteLine("Saque realizado com sucesso!\n");
                    }
                    break;

                case 5: //Depósito
                    float depos = Validacao("Digite o valor do depósito: ");
                    saldo += depos;
                    extrato.Add(new Extrato("Depósito", depos));
                    Console.Clear();
                    Console.WriteLine("Valor depositado com sucesso!\n");
                    break;

                case 6: //Extrato
                    Console.Clear();
                    foreach(var movimento in extrato)
                    {
                        movimento.Movimentos();
                    }
                    Console.WriteLine("\n");
                    break;

                case 7: //Transferência
                    float transf = Validacao("Digite o valor a ser transferido: ");
                    if(transf > saldo || transf > limite && limite > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Não foi possível transferir! Saldo insuficiente ou acima do limite da conta!\n");
                    }
                    else
                    {
                        extrato.Add(new Extrato("Transferência", transf));
                        saldo -= transf;
                        Console.Clear();
                        Console.WriteLine($"Transferência no valor de R${transf:F2} realizada com sucesso!\n");
                    }
                    break;

                case 0:
                    Console.Write("Saindo...");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Digite o número de serviço válido!\n");
                    break;
            }
        }
        while(opcao != 0);
    }
}
