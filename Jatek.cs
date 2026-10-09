using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsztraktEsInterface
{
    internal class Jatek
    {
        private Karakter? jatekos;
        private Harcos ellenfel;

        public Jatek()
        {
            ellenfel = new Harcos("A kristály őrzője");
        }

        public void Menu()
        {
            bool fut = true;

            while (fut)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("    A NÉGY KRISTÁLY ŐRZŐI");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Új hős létrehozása");
                Console.WriteLine("2. Hős adatainak megtekintése");
                Console.WriteLine("3. Harc a kristály őrzőjével");
                Console.WriteLine("4. Gyógyulás");
                Console.WriteLine("5. Szintlépés");
                Console.WriteLine("6. Arany és tapasztalat");
                Console.WriteLine("0. Kilépés");
                Console.Write("Választás: ");

                string? valasztas = Console.ReadLine();

                switch (valasztas)
                {
                    case "1":
                        KarakterLetrehozasa();
                        break;

                    case "2":
                        AdatokMegjelenitese();
                        break;

                    case "3":
                        Harc();
                        break;

                    case "4":
                        Gyogyitas();
                        break;

                    case "5":
                        Szintlepes();
                        break;

                    case "6":
                        JutalmakMegjelenitese();
                        break;

                    case "0":
                        fut = false;
                        Console.WriteLine("A játék véget ért.");
                        break;

                    default:
                        Console.WriteLine("Érvénytelen menüpont!");
                        break;
                }
            }
        }

        public void KarakterLetrehozasa()
        {
            Console.Write("Add meg a hős nevét: ");
            string nev = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(nev))
            {
                Console.WriteLine("A név nem lehet üres!");
                return;
            }

            Console.WriteLine("Válassz karaktertípust!");
            Console.WriteLine("1. Harcos");
            Console.WriteLine("2. Varázsló");
            Console.Write("Választás: ");

            string? tipus = Console.ReadLine();

            if (tipus == "1")
            {
                jatekos = new Harcos(nev);
            }
            else if (tipus == "2")
            {
                jatekos = new Varazslo(nev);
            }
            else
            {
                Console.WriteLine("Érvénytelen karaktertípus!");
                return;
            }

            Console.WriteLine("Sikeresen létrehoztad a hősödet!");
            Console.WriteLine(jatekos);
        }

        private void AdatokMegjelenitese()
        {
            if (jatekos == null)
            {
                Console.WriteLine("Először hozz létre egy hőst!");
                return;
            }

            Console.WriteLine("\n--- Hős adatai ---");
            Console.WriteLine(jatekos);

            if (jatekos is Varazslo varazslo)
            {
                Console.WriteLine(
                    $"Mana: {varazslo.Mana}/{varazslo.MaxMana}");
                Console.WriteLine($"Varázserő: {varazslo.Varazsero}");
            }

            if (jatekos is Harcos harcos)
            {
                Console.WriteLine($"Erő: {harcos.Ero}");
            }
        }

        public void Harc()
        {
            if (jatekos == null)
            {
                Console.WriteLine("Először hozz létre egy hőst!");
                return;
            }

            if (jatekos.EletEro <= 0)
            {
                Console.WriteLine(
                    "A hősöd elesett! Hozz létre egy új hőst.");
                return;
            }

            if (ellenfel.EletEro <= 0)
            {
                ellenfel = new Harcos("A kristály őrzője");
            }

            Console.WriteLine($"\n{jatekos.Nev} harcolni kezd!");
            Console.WriteLine(
                $"Ellenfél: {ellenfel.Nev}, életerő: {ellenfel.EletEro}");

            if (jatekos is ITamadhato tamado)
            {
                tamado.Tamadas(ellenfel);
            }

            if (ellenfel.EletEro <= 0)
            {
                Console.WriteLine("Legyőzted a kristály őrzőjét!");
                jatekos.JutalmatKap(30, 20);
                Console.WriteLine("Jutalmad: 30 tapasztalat és 20 arany.");
                ellenfel = new Harcos("A kristály őrzője");
                return;
            }

            Console.WriteLine(
                $"{ellenfel.Nev} visszatámad!");

            ellenfel.Tamadas(jatekos);

            if (jatekos.EletEro <= 0)
            {
                Console.WriteLine("A hősöd elesett!");
            }
        }

        private void Gyogyitas()
        {
            if (jatekos == null)
            {
                Console.WriteLine("Először hozz létre egy hőst!");
                return;
            }

            if (jatekos is IGyogyithato gyogyithato)
            {
                gyogyithato.Gyogyitas();
            }
        }

        private void Szintlepes()
        {
            if (jatekos == null)
            {
                Console.WriteLine("Először hozz létre egy hőst!");
                return;
            }

            if (jatekos.SzintetLep())
            {
                Console.WriteLine("Szintet léptél!");
                Console.WriteLine(jatekos);
            }
            else
            {
                Console.WriteLine(
                    "A szintlépéshez legalább 50 tapasztalat kell, " +
                    "és életben kell lenned.");
            }
        }

        private void JutalmakMegjelenitese()
        {
            if (jatekos == null)
            {
                Console.WriteLine("Először hozz létre egy hőst!");
                return;
            }

            Console.WriteLine($"Arany: {jatekos.Arany}");
            Console.WriteLine($"Tapasztalat: {jatekos.Tapasztalat}");
        }

    }
}