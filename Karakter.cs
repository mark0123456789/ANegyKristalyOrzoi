using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsztraktEsInterface
{
    public abstract class Karakter
    {
        public string Nev { get; set; }  
        public int Eletero { get; set; }
        public int MaxEletero { get; set; }
        public int Szint { get; set; }
        public int Tapasztalat { get; set; }
        public int Arany { get; set; }

        public int SebzestKap(int sebzes) 
        {
         return  Eletero -= sebzes;
        }

        public int SzintetLep() 
        {
            Szint++;
            Tapasztalat = 0;
            MaxEletero += 10;
            Eletero = MaxEletero;
            return Szint;
        }

        public override string? ToString()
        {
            return $"Név:{Nev},HP:{Eletero}/{MaxEletero},lvl:{Szint},XP:{Tapasztalat},Arany:{Arany}";
        }
    }
}
