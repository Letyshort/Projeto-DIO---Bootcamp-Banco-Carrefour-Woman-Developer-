using System;
using System.Runtime;
using Projeto_DIO___Bootcamp_Banco_Carrefour_Woman_Developer.Enums;
#nullable disable

namespace Projeto_DIO___Bootcamp_Banco_Carrefour_Woman_Developer
{
  class Program
  {
    static SerieRepositorio _repositorio = new SerieRepositorio();

    static void Main()
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSerie();
            break;
          case "2":
            InsereSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();

        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1. Listar séries");
      Console.WriteLine("2. Inserir nova série");
      Console.WriteLine("3. Atualizar série");
      Console.WriteLine("4. Excluir série");
      Console.WriteLine("5. Visualizar série");
      Console.WriteLine("C. Limpar tela");
      Console.WriteLine("X. Sair");
      Console.WriteLine();

      var opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }

    public static void InsereSerie()
    {
      Console.WriteLine("Inserir nova série:");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine($"{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = Convert.ToInt32(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      var entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = Convert.ToInt32(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      var entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: _repositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);


      _repositorio.Insere(novaSerie);
    }

    private static void ListarSerie()
    {
      Console.WriteLine("Listar séries:");

      var lista = _repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }
      foreach (var serie in lista)
      {
        var excluido = serie.RetornaExcluido();

        Console.WriteLine($"ID{0} : - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "'Excluido'" : ""));
      }
    }

    private static void ExcluirSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      _repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = Convert.ToInt32(Console.ReadLine());

      var serie = _repositorio.RetornaPorId(indiceSerie);

      Console.WriteLine(serie);
    }
    private static void AtualizarSerie()
    {
      Console.Write("Digite o ID da série: ");
      int indiceSeries = Convert.ToInt32(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine($"{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = Convert.ToInt32(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      var entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = Convert.ToInt32(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      var entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSeries,
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);

      _repositorio.Atualiza(indiceSeries, atualizaSerie);
    }
  }
}
