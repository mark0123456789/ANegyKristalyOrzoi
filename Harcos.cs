using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsztraktEsInterface
{
    internal class Harcos : Karakter, ITamadhato, IGyogyithato
    {
        public int Ero { get; set; }

        public void Tamadas(Karakter celpont)
        {
            if (celpont == null || Eletero <= 0)
            {
                return;
            }
            celpont.SebzestKap(Ero);
            Console.WriteLine($"{Nev} Megtámadta az ellenfelet. Sebzés:{Ero}");
        }
        public void Gyogyitas()
        {
            if (Eletero <=0)
            {
                return;
            }
            Eletero += 20;
            if (Eletero > MaxEletero)
            {
                Eletero = MaxEletero;
                Console.WriteLine($"{Nev} Maximális életerejére gyógyult({MaxEletero})");
            }
            Console.WriteLine($"{Nev} 20 életerőt gyógyult");
        }
    }
}
        

