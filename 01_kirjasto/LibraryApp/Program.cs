using LibraryApp.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

public class Program
{
    private static void Main(string[] args)
    {
        DataBaseRepository dataBaseRepository = new DataBaseRepository("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        dataBaseRepository.IsDbConnectionEstablished();

        // Hae kaikki kirjat, jotka on julkaistu viiden vuoden sisällä. Tulosta kirjat konsoliin.
        dataBaseRepository.GetBooksFromFiveYears();
        // Hae kirjaston asiakkaiden keski-ikä. Tulosta keski-ikä konsoliin. Jos ikää ei ole, niin lisää syntymäaika tietokantaan.
        dataBaseRepository.GetCUstomersCenterAge();
        // Hae kirja, joita on eniten tarjolla kirjastossa. Tulosta kirjan nimi konsoliin.
        dataBaseRepository.GetBookWitchContainsMost();
        // Hae jäsenet, jotka lainasivat ainakin yhden kirjan kirjastosta. Tulosta jäsenen nimi ja kirjan ISBN konsoliin.
        dataBaseRepository.GetMemberHowLoan();
        // (Bonus) Hae kolmen lainatuimman kirjan kaikki tiedot konsoliin. Vihje! Tarvitset useamman Join-lauseen.
        dataBaseRepository.GetThreeMostLoanBook();
    }
}