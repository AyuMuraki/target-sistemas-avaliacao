using System.Text.Json;
using Target_v1.Models;

namespace Target_v1.Services
{
    public static class LerArquivoServices
    {
        public static List<FaturamentoDiario> LerArquivo()
        {
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArquivoJson", "jsonTeste.json");
            if (File.Exists(caminhoArquivo))
            {
                string jsonstring = File.ReadAllText(caminhoArquivo);

                List<FaturamentoDiario> faturamentoDiarios = new List<FaturamentoDiario>();
                faturamentoDiarios = JsonSerializer.Deserialize<List<FaturamentoDiario>>(jsonstring);
                return faturamentoDiarios;
            }
            else
            {
                return null;
            }



        }

    }
}
