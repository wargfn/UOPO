using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UOPO.Models
{
    public class SoloCards
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FrontText { get; set; }
        public string BackTextOption1 { get; set; }
        public string BackTextOption2 { get; set; }
        public string RewardsOption1 { get; set; }
        public string RewardsOption2 { get; set; }
        public string Reward { get; set; }
        public string CardSet { get; set; }
        public string CardType { get; set; }
        public int? CardNum { get; set; }
    }
}