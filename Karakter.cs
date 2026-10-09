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

        public void SebzestKap(int sebzes) 
        {
            if (sebzes <0)
            {
                return;
            }
            Eletero -= sebzes;
            if (Eletero <0)
            {
                Eletero = 0;
            }
        }

        public void SzintetLep() 
        {
            Szint++;
            Tapasztalat = 0;
            MaxEletero += 10;
            Eletero = MaxEletero;
           
        }

        public override string? ToString()
        {
            return $"Név:{Nev},HP:{Eletero}/{MaxEletero},lvl:{Szint},XP:{Tapasztalat},Arany:{Arany}";
        }
    }
}
