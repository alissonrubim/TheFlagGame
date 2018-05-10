using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheFlagGame.Models
{
    public class ViewResult
    {
        public List<PlayerFlag> PlayerFlags = new List<PlayerFlag>();
        public string EmailShare { get; set; }
        public int TotalPoints { get; set; }
    }
}