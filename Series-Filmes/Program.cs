using System;
using Series.Interfaces;

namespace Series
{
	class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmesRepositorio repositorioF = new FilmesRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
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
					case "6":
						ListarFilmes();
						break;
					case "7":
						InserirFilmes();
						break;
					case "8":
						AtualizarFilmes();
						break;
					case "9":
						ExcluirFilmes();
						break;
					case "10":
						VisualizarFilmes();
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
		
		private static void ExcluirFilmes()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			repositorioF.Exclui(indiceFilmes);
			
		}
		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
			
		}
		private static void VisualizarFilmes()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			var filme = repositorioF.RetornaPorId(indiceFilmes);

			Console.WriteLine(filme);
		}
		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void AtualizarFilmes()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o Ano do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filmes atualizaFilmes = new Filmes(id: indiceFilmes,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			repositorioF.Atualiza(indiceFilmes, atualizaFilmes);
		}
		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o Título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a Descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

		private static void ListarFilmes()
		{
			Console.WriteLine("Listar Filmes");

			var lista = repositorioF.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrada.");
				return;
			}

			foreach (var filmes in lista)
			{
				var excluido = filmes.retornaExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", filmes.retornaId(), filmes.retornaTitulo(), (excluido ? "*Excluio*" : ""));
			}
		}
		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluio*" : ""));
			}
		}

		private static void InserirFilmes()
		{
			Console.WriteLine("Inserir novo filme");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o Ano do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filmes novoFilme = new Filmes(id: repositorioF.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			repositorioF.Insere(novoFilme);
			
		}
		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o Título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a Descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			repositorio.Insere(novaSerie);
			
		}
		
		private static string ObterOpcaoUsuario()
		{
			System.Console.WriteLine();
			System.Console.WriteLine("Séries a seu dispor!!");
			System.Console.WriteLine("Informe a opção desejada:");

			System.Console.WriteLine("1- Listar séries");
			System.Console.WriteLine("2- Inserir nova série");
			System.Console.WriteLine("3- Atualizar série");
			System.Console.WriteLine("4- Excluir série");
			System.Console.WriteLine("5- Visualizar série");			
			System.Console.WriteLine("6- Listar filmes");
			System.Console.WriteLine("7- Inserir novo filme");
			System.Console.WriteLine("8- Atualizar filme");
			System.Console.WriteLine("9- Excluir filme");
			System.Console.WriteLine("10- Visualizar filme");
			System.Console.WriteLine("11- Limpar tela");
			System.Console.WriteLine("X- Sair");
			System.Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			System.Console.WriteLine();
			return opcaoUsuario;
		}
	}
}