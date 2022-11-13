using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Spell
    {
        public long Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int AvailablePerTurn { get; set; }

        public long PlayerId { get; set; }
        [JsonIgnore]
        public Player Player { get; set; }
    }
}
