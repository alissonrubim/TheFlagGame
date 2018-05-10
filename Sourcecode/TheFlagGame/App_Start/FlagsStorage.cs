using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheFlagGame.Models;

namespace TheFlagGame.App_Start
{
    public class FlagsStorage
    {
        private List<Flag> flags = new List<Flag>();

        public FlagsStorage()
        {
            this.flags.Add(new Flag()
            {
                Name = "Brasil",
                ImagePath = "brasil.png",
                Weight = 1
            });
            this.flags.Add(new Flag()
            {
                Name = "Alemanha",
                ImagePath = "alemanha.png",
                Weight = 5
            });
            this.flags.Add(new Flag()
            {
                Name = "Estados Unidos",
                ImagePath = "estadosunidos.png",
                Weight = 6
            });
            this.flags.Add(new Flag()
            {
                Name = "Franca",
                ImagePath = "franca.png",
                Weight = 10
            });
            this.flags.Add(new Flag()
            {
                Name = "Italia",
                ImagePath = "italia.png",
                Weight = 8
            });
            this.flags.Add(new Flag()
            {
                Name = "Irlanda",
                ImagePath = "irlanda.png",
                Weight = 2
            });
            this.flags.Add(new Flag()
            {
                Name = "Argentina",
                ImagePath = "argentina.png",
                Weight = 1
            });
            this.flags.Add(new Flag()
            {
                Name = "Japao",
                ImagePath = "japao.png",
                Weight = 2
            });
            this.flags.Add(new Flag()
            {
                Name = "Coreia",
                ImagePath = "coreia.png",
                Weight = 7
            });
            this.flags.Add(new Flag()
            {
                Name = "China",
                ImagePath = "china.png",
                Weight = 4
            });
        }

        public int Count()
        {
            return flags.Count;
        }

        public Flag GetAt(int index)
        {
            if (index >= 0 || index < flags.Count)
                return flags[index];
            return null;
        }

        public Flag GetById(Guid index)
        {
            return flags.Where(f => f.Id.Equals(index)).FirstOrDefault();
        }
    }
}