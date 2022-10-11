using Lesson13_14_savarankiskas.@class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_14_savarankiskas
{
    internal class HumanRepozitory
    {
        public List<Human> AllHumans { get; set; }

        public HumanRepozitory()
        {
            AllHumans = new List<Human>();
            AllHumans.Add(new Human("Lukas", 1, 10, 1));
            AllHumans.Add(new Human("Adomas", 2, 10, 3));
            AllHumans.Add(new Human("Kristina", 3, 10, 2));
            AllHumans.Add(new Human("Adomas", 4, 10, 4));
            AllHumans.Add(new Human("Lina", 5, 10, 2));
            AllHumans.Add(new Human("Karolina", 6, 10, 2));
            AllHumans.Add(new Human("Adomas", 7, 10, 3));
            AllHumans.Add(new Human("Ignas", 8, 10, 1));
            AllHumans.Add(new Human("Doma", 9, 10, 4));
            AllHumans.Add(new Human("Paulius", 10, 10, 3));

        }


        public List<Human> Retrieve()
        {
            return AllHumans;
        }
        public Human Retrieve(int humanId)
        {
            return AllHumans.Where(c => c.HumanId == humanId).FirstOrDefault();
        }
    }
}
