using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UOPO.Models;

namespace UOPO.DTOs
{
    public class AdventuresDTO
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public EncounterListModel GetEncounterList { get; set; }
        public byte EncounterId { get; set; }
    }
}