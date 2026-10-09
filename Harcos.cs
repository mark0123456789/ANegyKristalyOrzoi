using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsztraktEsInterface
{
    internal class Harcos : Karakter, ITamadhato, IGyogyithato
    {
        public int Ero { get; private set; }

        public override string Tipus => "Harcos";

        public Harcos(string nev)
            : base(nev, 120)
        {
            Ero = 20;
        }

        public void Tamadas(Karakter celpont)
        {
            if (celpont == null || EletEro <= 0)
            {
                return;
            }

            celpont.SebzestKap(Ero);

            Console.WriteLine(
                $"{Nev} karddal támadott! Sebzés: {Ero}");
        }

        public void Gyogyitas()
        {
            if (EletEro <= 0 || EletEro == MaxEletEro)
            {
                Console.WriteLine("Most nem tudsz gyógyulni!");
                return;
            }

            EletEro += 20;

            if (EletEro > MaxEletEro)
            {
                EletEro = MaxEletEro;
            }

            Console.WriteLine($"{Nev} használt egy gyógyitalt.");
        }
    }
}
        

