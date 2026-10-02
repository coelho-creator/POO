namespace POO;

public abstract class Animal
{
    public string Nome { get; private set; }
    public int Idade { get; private set; }
    
    protected Animal(string nome, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome não pode estar vazio ou nulo!", nameof(nome));
        }

        if (int.IsNegative(idade))
        {
            throw new ArgumentOutOfRangeException("A idade não pode ser negativa!", nameof(idade));
        }
        
        Nome = nome;
        Idade = idade;
    }
    
    public void Comer()
    {
        Console.WriteLine($"O {Nome} esta comendo!"); //interpolação
    }
    
    public virtual void FazerBarulho()
    {
        Console.WriteLine($"{Nome} fez barulho");
    }
}