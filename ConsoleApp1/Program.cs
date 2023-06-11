using System;
using System.Diagnostics;
using System.Globalization;
using Demo;
using SpotifyAPI.Web;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDate = DateUtils.CurrentDate();
            Console.WriteLine(currentDate + '\n');
            CommandLineToArtist(args).GetAwaiter().GetResult();
        }
        static async Task CommandLineToArtist(string[] args)
        {
            Console.WriteLine("Informe o nome de um cantor/músico");
            string artist = Console.ReadLine();
            Console.WriteLine($"Deseja ler a biografia de {artist}? (Y/N)");
            ConsoleKeyInfo key = Console.ReadKey();
            if (char.ToLower(key.KeyChar) == 'y')
            {
                await OpenLinkInBrowser(artist);
                //await PlayFamousSong(artist);
            }
            else if (char.ToLower(key.KeyChar) == 'n')
            {
                Console.WriteLine("\nFechando o terminal...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                Console.WriteLine();
                await CommandLineToArtist(args);
            }
        }
        static async Task OpenLinkInBrowser(string artist)
        {
            if (!string.IsNullOrEmpty(artist))
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string capitalizedArtist = textInfo.ToTitleCase(artist.ToLower());
                string openWikipedia = $"https://pt.wikipedia.org/wiki/{capitalizedArtist.Replace(" ", "_")}";
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = openWikipedia,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao abrir o link: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("O nome do cantor/músico não pode estar vazio.");
            }
        }
        //static async Task PlayFamousSong(string artist)
        //{
        //    string artistName = artist;
        //    var spotify = new SpotifyClient("9d639146cde6450b966169157524379b");
        //    var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
        //    Console.WriteLine(track.Name);
        //}
    }
}