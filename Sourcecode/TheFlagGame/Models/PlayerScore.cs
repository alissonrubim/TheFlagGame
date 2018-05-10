using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheFlagGame.App_Start;

namespace TheFlagGame.Models
{
    public class Player
    {
        public List<DrawnFlags> DrawnFlags = new List<DrawnFlags>();
        public List<PlayerFlag> PlayerFlags = new List<PlayerFlag>();

        public void GenerateDrawnFlags(FlagsStorage flagsStorage)
        {
            Random rand = new Random();
            while (this.DrawnFlags.Count() < flagsStorage.Count())
            {
                DrawnFlags randFlag = null;
                do
                {
                    randFlag = new DrawnFlags();
                    randFlag.Answer = flagsStorage.GetAt(rand.Next(0, flagsStorage.Count()));

                    randFlag.Options.Add(randFlag.Answer);

                    var i = 0;
                    while (i < 3)
                    {
                        Flag flg = flagsStorage.GetAt(rand.Next(0, flagsStorage.Count()));
                        if (randFlag.Options.Where(f => f.Id.Equals(flg.Id)).Count() == 0)
                        {
                            randFlag.Options.Add(flg);
                            i++;
                        }
                    }

                    randFlag.Options = randFlag.Options.OrderBy(a => Guid.NewGuid()).ToList();
                }
                while (this.DrawnFlags.Where(r => r.Answer.Id == randFlag.Answer.Id).Count() != 0);
                this.DrawnFlags.Add(randFlag);
            }
        }
    }

    public class DrawnFlags
    {
        public Flag Answer { get; set; }
        public List<Flag> Options { get; set; } = new List<Flag>();
    }

    public class PlayerFlag
    {
        public Flag CorrectFlag { get; set; }
        public Flag ChoiseFlag { get; set; }
    }
}