

using System.Collections;
var nomes = new ArrayList() { "Pedro", "Maria Eduarda" };

//acesso por indice
Console.WriteLine($"Primeiro item da lista:{nomes[0]}");

//formas de percorrer toda a coleção
Console.WriteLine("Percorrendo com for");

for (int i = 0; i < nomes.Count; i++)
{
    Console.WriteLine(nomes[i]);
}

Console.WriteLine("Percorrendo com foreach");
foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}

//Colecao personalizada
Console.WriteLine("Coleção personalizada");
var listaNomes = new ListaNomes();

foreach (var nome in listaNomes) Console.WriteLine(nome);

//Coleção personalizada utilizando o operador yield return
Console.WriteLine("Coleção personalizada yield");
var listaNomesYield = new ListaNomesYield();
foreach (var nome in listaNomesYield) Console.WriteLine(nome);

public class ListaNomesEnumerator : IEnumerator
{
    private int indice = -1;

    private string[] nomes = new string[] { "Pedro", "Maria Eduarda" };
    public object Current => nomes[indice];

    public bool MoveNext()
    {
        if (indice < nomes.Length - 1)
        {
            indice++;
            return true;
        }

        return false;

    }

    public void Reset()
    {
        indice = -1;
    }
}

public class ListaNomes : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        return new ListaNomesEnumerator();
    }
}

public class ListaNomesYield : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return "Pedro";
        yield return "Maria Eduarda";
    }
}