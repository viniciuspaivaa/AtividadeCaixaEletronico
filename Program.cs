using System.Diagnostics.Contracts;


int opcao;
float saldo = 0;
float limite = 0;
bool contaCorrente = true;


Console.WriteLine("=".PadLeft(19, '='));
Console.WriteLine("Bem-vindo ao caixa!");
Console.WriteLine("=".PadLeft(19, '='));


Console.Write("1. Verificar saldo\n2. Tipo de conta\n3. Limite da conta\n4. Saque\n5. Depósito\n6. Extrato\n7. Transferência\n0. Sair\nDigite a opção desejada: ");
while(!int.TryParse(Console.ReadLine(), out opcao))
{
    Console.Write("Número inválido! Tente novamente: ");
}


switch(opcao)
{
    case 1:
        Console.Clear();
        Console.Write($"Seu saldo na conta é R${saldo:F2}!");
        break;
    case 2:
        Console.Clear();
        string tipoConta = contaCorrente ? "corrente" : "poupança";
        Console.Write($"O tipo da sua conta é {tipoConta}!");
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
            break;
        }
        Console.Clear();
        break;
    case 4:
        if(saldo <= 0)
        {
            Console.Write("Você não possui nenhum dinheiro para sacar!");
        }
        else
        {
            Console.Write("Digite o valor do saque: ");
            saldo -= int.Parse(Console.ReadLine());
        }
        Console.Clear();
        Thread.Sleep(2000);
        Console.Write("Saque realizado com sucesso!");
        break;
}

