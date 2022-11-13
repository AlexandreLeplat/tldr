using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class PlayerAction
    {
        public long Id { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public string Description { get; set; }
        public DateTime ActionDate { get; set; }

        // Type d'action
        public long SpellId { get; set; }
        [JsonIgnore]
        public Spell Spell { get; set; }

        // Liste des changements sur la carte
        [NotMapped]
        public List<TileChange> TileChanges { get; set; }
    }
}