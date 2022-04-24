using Projeto_DIO___Bootcamp_Banco_Carrefour_Woman_Developer.Enums;

namespace Projeto_DIO___Bootcamp_Banco_Carrefour_Woman_Developer
{
  public class Serie : EntidadeBase
  {
    //Atributos

    private Genero Genero { get; set; }

    private string Titulo { get; set; }

    private string Descricao { get; set; }

    private int Ano { get; set; }

    private bool Excluido { get; set; }

    //Métodos

    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
    {
      Id = id;
      Genero = genero;
      Titulo = titulo;
      Descricao = descricao;
      Ano = ano;
      Excluido = false;
    }

    public override string ToString()
    {
      //Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
      var retorno = "";
      retorno += "Gênero: " + Genero + Environment.NewLine;
      retorno += "Título: " + Titulo + Environment.NewLine;
      retorno += "Descrição: " + Descricao + Environment.NewLine;
      retorno += "Ano de Início: " + Ano + Environment.NewLine;
      retorno += "Excluido: " + Excluido;
      return retorno;
    }

    public string RetornaTitulo() => Titulo;

    public int RetornaId() => Id;

    public bool RetornaExcluido() => Excluido;

    public void Excluir() => Excluido = true;
  }
}