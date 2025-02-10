using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tehenek
{
    class Tehen : IEquatable<Tehen>
    {

        public string Id { get; private set; }
        public int[] Mennyisegek { get; private set; }

        public bool Equals(Tehen masik)
        {
            return masik != null && masik.Id == this.Id;
        }

        public void EredmenytRogzit(string nap, string menyiseg)
        {
            Mennyisegek[int.Parse(nap)] = int.Parse(menyiseg);
        }

        public Tehen(string id)
        {
            Id = id;
            Mennyisegek = new int[7];
        }

        public int HetiTej => Mennyisegek.Sum();

        public int HetiAtlag
        {
            get
            {
                double hetiDarab = Mennyisegek.Count(x => x != 0);
                if (hetiDarab >= 3) return (int)Math.Round(HetiTej / hetiDarab, 0, MidpointRounding.AwayFromZero);
                else return -1;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tehen> happyCows = new List<Tehen>();
            foreach (var sor in File.ReadAllLines("hozam.txt"))
            {
                string id = sor.Split(';')[0];
                string nap = sor.Split(';')[1];
                string mennyiseg = sor.Split(';')[2];
                Tehen aktTehen = new Tehen(id);

                if (!happyCows.Contains(aktTehen)) {
                    happyCows.Add(aktTehen);
                }
                int index = happyCows.IndexOf(aktTehen);
                happyCows[index].EredmenytRogzit(nap, mennyiseg);
            }

            Console.WriteLine($"3. feladat:\nAz állomány {happyCows.Count} tehén adatait tartalmazza.");




        }
    }
}
