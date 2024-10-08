using System.Diagnostics.Contracts;


class Extrato
{
    public float Valor {get; set;}
    public string DataHora {get; set;}

    public Extrato(float valor)
    {
        Valor = valor;
        DataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }

    public void Movimentos()
    {
        if(Valor < 0)
        {
        Console.WriteLine($"Saque     R${Valor:F2}   {DataHora}");
        }
        else
        {
        Console.WriteLine($"Deposito  R${Valor:F2}   {DataHora}");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        int opcao = 0;
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
            while(!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Número inválido! Tente novamente: ");
            }


            switch(opcao)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine($"Seu saldo na conta é R${saldo:F2}!\n");
                    break;
                case 2:
                    Console.Clear();
                    string tipoConta = contaCorrente ? "corrente" : "poupança";
                    Console.WriteLine($"O tipo da sua conta é {tipoConta}!\n");
                    break;
                case 3:
                    Console.WriteLine($"O limite da conta atual é R${limite:F2}, pressione Enter para adicionar um novo limite ou pressione outra tecla para sair...");
                    var key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.Enter)
                    {
                        Console.Write("Digite o novo saldo: ");
                        saldo = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Novo limite adicionado!\n");
                    break;
                case 4:
                    if(saldo <= 0)
                    {
                        Console.Write("Você não possui nenhum dinheiro para sacar!");
                    }
                    else
                    {
                        Console.Write("Digite o valor do saque: ");
                        float saque = float.Parse(Console.ReadLine());
                        saldo -= saque;
                        extrato.Add(new Extrato(-saque));
                    }
                    Console.Clear();
                    Thread.Sleep(2000);
                    Console.WriteLine("Saque realizado com sucesso!\n");
                    break;
                case 5:
                    Console.Write("Digite o valor do depósito: ");
                    float depos = float.Parse(Console.ReadLine());
                    saldo += depos;
                    extrato.Add(new Extrato(depos));
                    Console.Clear();
                    Console.WriteLine("Valor depositado com sucesso!\n");
                    break;
                case 6:
                    foreach(var movimento in extrato)
                    {
                        movimento.Movimentos();
                    }
                    Console.WriteLine("\n");
                    break;
            }
        }
        while(opcao != 0);
    }

}
