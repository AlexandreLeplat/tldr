using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Campaign
    {
        public long Id { get; set; }

        public string Name { get; set; }

        // Date du prochain tour
        public DateTime NextTurn { get; set; }

        // Numéro du tour en cours
        public int CurrentTurn { get; set; }

        // Statut de la campagne
        public CampaignStatus Status { get; set; }

        // Liste des caractéristiques de la campagne regroupées par catégories
        [NotMapped]
        public Dictionary<string, Dictionary<string, string>> Assets
        {
            get { return _jsonAssets == null ? null : JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(_jsonAssets); }
            set { _jsonAssets = JsonSerializer.Serialize(value); }
        }
        [JsonIgnore]
        public string _jsonAssets { get; set; }

        public long CreatorId { get; set; }
        [JsonIgnore]
        public User Creator { get; set; }

        [JsonIgnore]
        public List<Player> Players { get; set; }

        // Liste des cartes de la campagne
        [JsonIgnore]
        public List<Map> Maps { get; set; }
    }
}
