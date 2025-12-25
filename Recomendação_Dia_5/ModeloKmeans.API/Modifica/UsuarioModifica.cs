using System.Collections;

namespace ModeloKmeans.Modifica;

internal static class UsuarioModifica
{
    public static Dictionary<int, List<string>> LeArquivoUsuario()
    {
        using (StreamReader sr = new StreamReader(@"..\..\DS_Dia_4\u.user"))
        {
            List<string> textoLista = new();
            string? usuarioDado;

            while ((usuarioDado = sr.ReadLine()) is not null)
            {
                textoLista.Add(usuarioDado);
            }

            Dictionary<int, List<string>> usuariosDict = new();

            foreach (var texto in textoLista)
            {
                string[] partesFilmes = texto.Replace("|", ",").Trim().Split(',');

                int id = int.Parse(partesFilmes[0]);
                string idade = partesFilmes[1];
                string genero = partesFilmes[2];

                List<string> atributos = new();
                atributos.Add(idade);
                atributos.Add(genero);

                usuariosDict[id] = atributos;
            }

            return usuariosDict;
        }
    }

    public static List<string> LeArquivoAvaliacoes() 
    {
        using (StreamReader sr = new StreamReader(@"..\..\DS_Dia_4\u.data"))
        {
            List<string> texto = new();
            string? usuarioDado;

            while ((usuarioDado = sr.ReadLine()) is not null)
            {
                texto.Add(usuarioDado);
            }

            return texto;
        }
    }

    private static List<string> LeArquivoFilmes() 
    {
        using (StreamReader sr = new StreamReader(@"..\..\DS_Dia_4\u.item"))
        {
            List<string> texto = new();
            string? filmeDado;

            while ((filmeDado = sr.ReadLine()) is not null)
            {
                texto.Add(filmeDado);
            }

            return texto;
        }
    }

    public static List<int> TodosFilmesRegistrados()
    {
        List<string> textoLista = LeArquivoFilmes();
        List<int> registrosFilmes = new();

            foreach (var texto in textoLista)
            {
                string[] partesFilmes = texto.Replace("|", ",").Trim().Split(',');

                int id = int.Parse(partesFilmes[0]);
                registrosFilmes.Add(id);
            }
            
        return registrosFilmes;
    }
}