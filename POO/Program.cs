namespace POO;

class Program
{
    static void Main()
    {
        Animal[] animais =
        [
            new Cachorro("Julio", 2),
            new Gato("Zeus", 5),
            new Vaca("Geraldo", 7)
        ];

        foreach (var animalAtual in animais)
        {
            animalAtual.Comer();
            animalAtual.FazerBarulho();
        }
    }
}