using System.Diagnostics.Contracts;

int opcao;
int saldo = 0;
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
        string tipoConta = contaCorrente ? "corrente" : "poupança";
        Console.Write($"O tipo da sua conta é {tipoConta}!");
        break;

}
