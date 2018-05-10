using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheFlagGame.Models
{
    public class ViewFlags
    {
        public int CurrentGameIndex { get; set; }
        public Flag Answer { get; set; }
        public List<Flag> Options { get; set; }
    }
}