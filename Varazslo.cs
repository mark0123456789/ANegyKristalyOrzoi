using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsztraktEsInterface
{
    internal class Varazslo : Karakter, IGyogyithato, ITamadhato
    {
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int Varazsero { get; set; }

        public void Tamadas(Karakter celpont)
        {
            if (celpont == null || Eletero <= 0 || Mana < 10)
            {
                return;
            }
            Mana -= 10;
            celpont.SebzestKap(Varazsero);
            Console.WriteLine($"{Nev} Megtámadta az ellenfelet. Sebzés:{Varazsero}, Mana({Mana}/{MaxMana})");
        }
        public void Gyogyitas()
        {
            if (Eletero <= 0 || Mana < 15)
            {
                return;
            }
            Mana -= 15;
            Eletero += 20;
            if (Eletero > MaxEletero)
            {
                Eletero = MaxEletero;
                Console.WriteLine($"{Nev} Maximális életerejére gyógyult({MaxEletero})");
            }
            Console.WriteLine($"{Nev} 20 életerőt gyógyult, Mana({Mana}/{MaxMana})");
        }
    }
}
