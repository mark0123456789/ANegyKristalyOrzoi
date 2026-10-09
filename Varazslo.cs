using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsztraktEsInterface
{
    internal class Varazslo : Karakter, IGyogyithato, ITamadhato
    {
        public int Mana { get; private set; }
        public int MaxMana { get; private set; }
        public int Varazsero { get; private set; }

        public override string Tipus => "Varázsló";

        public Varazslo(string nev)
            : base(nev, 80)
        {
            Mana = 50;
            MaxMana = 50;
            Varazsero = 30;
        }

        public void Tamadas(Karakter celpont)
        {
            if (celpont == null || EletEro <= 0)
            {
                return;
            }

            if (Mana < 10)
            {
                Console.WriteLine("Nincs elég manád a támadáshoz!");
                return;
            }

            Mana -= 10;
            celpont.SebzestKap(Varazsero);

            Console.WriteLine(
                $"{Nev} varázslattal támadott! Sebzés: {Varazsero}");
            Console.WriteLine($"Hátralévő mana: {Mana}/{MaxMana}");
        }

        public void Gyogyitas()
        {
            if (EletEro <= 0 || EletEro == MaxEletEro)
            {
                Console.WriteLine("Most nem tudsz gyógyulni!");
                return;
            }

            if (Mana < 15)
            {
                Console.WriteLine("Nincs elég manád a gyógyításhoz!");
                return;
            }

            Mana -= 15;
            EletEro += 30;

            if (EletEro > MaxEletEro)
            {
                EletEro = MaxEletEro;
            }

            Console.WriteLine($"{Nev} gyógyító varázslatot használt.");
            Console.WriteLine($"Hátralévő mana: {Mana}/{MaxMana}");
        }
    }
}
