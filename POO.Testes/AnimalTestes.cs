namespace POO.Testes;

[TestClass]
[DoNotParallelize]
public sealed class AnimalTestes
{
    private StringWriter _consoleOutput;
    private TextWriter _originalOutput;

    [TestInitialize]
    public void Setup()
    {
        _consoleOutput = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_consoleOutput);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(_originalOutput);
        _consoleOutput.Dispose();
    }
    
    [TestMethod]
    public void ShouldReturnObjectCachorro_WhenNomeAndIdadeCorrect()
    {
        //arrange
        string nomeEsperado = "Julio";
        int idadeEsperado = 2;
        
        //act
        var animal = new Cachorro(nomeEsperado, idadeEsperado);
        
        //assert
        Assert.AreEqual(nomeEsperado, animal.Nome);
        Assert.AreEqual(idadeEsperado, animal.Idade);
    }
    
    [TestMethod]
    public void QuandoInvocadoComer_DeveEscreverMensagemPadraoNoConsole()
    {
        //arrange
        string nome = "Miaton";
        var animal = new Gato(nome, 3);
        string menssagemEsperada = ($"O {nome} esta comendo!{Environment.NewLine}");
        
        //act
        animal.Comer();
        
        //assert
        Assert.AreEqual(menssagemEsperada, _consoleOutput.ToString());
        
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaVaca_DveFazerMuMu()
    {
        //arrange
        string nome = "Minotauro";
        var animal = new Vaca(nome, 3);
        string menssagemEsperada = ($"{nome} fez MuMu{Environment.NewLine}");
        
        //act
        animal.FazerBarulho();
        
        //assert
        Assert.AreEqual(menssagemEsperada, _consoleOutput.ToString());
    }
    
    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaGato_DveFazerMiaU()
    {
        //arrange
        string nome = "Bambi";
        var animal = new Gato(nome, 2);
        string menssagemEsperada = ($"{nome} fez MiaU{Environment.NewLine}");
        
        //act
        animal.FazerBarulho();
        
        //assert
        Assert.AreEqual(menssagemEsperada, _consoleOutput.ToString());
    }
    
    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaCachorro_DveFazerAuAu()
    {
        //arrange
        string nome = "Jorge";
        var animal = new Cachorro(nome, 5);
        string menssagemEsperada = ($"{nome} fez AuAu{Environment.NewLine}");
        
        //act
        animal.FazerBarulho();
        
        //assert
        Assert.AreEqual(menssagemEsperada, _consoleOutput.ToString());
    }
    
    // Unhappy Test
    [TestMethod]
    public void QuandoInstanciarComNomeVazio_Sempre_DeveLancarArgumentException()
    {
        //arrange
        string nomeAnimal = "";
        
        //act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 0));
        Assert.Contains("O nome não pode estar vazio ou nulo!", excecao.Message);
    }

    [TestMethod]
    public void QuandoInstanciarComNomeNulo_Sempre_DeveLancarArgumentException()
    {
        //arrange
        string nomeAnimal = null;
        
        //act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 0));
        Assert.Contains("O nome não pode estar vazio ou nulo!", excecao.Message);
    }

    [TestMethod]
    public void QuandoInstanciarComIdadeNegativa_Sempre_DeveLancarArgumentOutOfRangeException()
    {
        //arrange
        int idade = -1;
        
        //act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new Cachorro("Chico", idade));
        Assert.Contains("A idade não pode ser negativa!", excecao.Message);
    }
}
