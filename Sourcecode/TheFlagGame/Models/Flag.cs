using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheFlagGame.Models
{
    public class Flag
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Weight { get; set; }
        public Guid Id { get; set; }

        public Flag()
        {
            this.Id = Guid.NewGuid();
        }
    }
}