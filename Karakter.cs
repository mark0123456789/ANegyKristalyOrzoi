using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsztraktEsInterface
{
    public abstract class Karakter
    {
        public string Nev { get; private set; }
        public int EletEro { get; protected set; }
        public int MaxEletEro { get; protected set; }
        public int Szint { get; private set; }
        public int Tapasztalat { get; private set; }
        public int Arany { get; private set; }

        public abstract string Tipus { get; }

        protected Karakter(string nev, int eletEro)
        {
            Nev = nev;
            EletEro = eletEro;
            MaxEletEro = eletEro;
            Szint = 1;
            Tapasztalat = 0;
            Arany = 0;
        }

        public void SebzestKap(int sebzes)
        {
            if (sebzes < 0 || EletEro <= 0)
            {
                return;
            }

            EletEro -= sebzes;

            if (EletEro < 0)
            {
                EletEro = 0;
            }
        }

        public bool SzintetLep()
        {
            if (EletEro <= 0 || Tapasztalat < 50)
            {
                return false;
            }

            Tapasztalat -= 50;
            Szint++;
            MaxEletEro += 10;
            EletEro += 10;

            if (EletEro > MaxEletEro)
            {
                EletEro = MaxEletEro;
            }

            return true;
        }

        public void JutalmatKap(int tapasztalat, int arany)
        {
            Tapasztalat += tapasztalat;
            Arany += arany;
        }

        public override string ToString()
        {
            return $"Név: {Nev}\n" +
                   $"Típus: {Tipus}\n" +
                   $"Életerő: {EletEro}/{MaxEletEro}\n" +
                   $"Szint: {Szint}\n" +
                   $"Tapasztalat: {Tapasztalat}\n" +
                   $"Arany: {Arany}";
        }
    }
}
