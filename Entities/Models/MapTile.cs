﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Entities.Models
{
    public class MapTile
    {
        public long Id { get; set; }
        public string Name { get; set; }

        // Coordonnées sur la carte
        public int X { get; set; }
        public int Y { get; set; }

        // Apparence sur la carte
        public string Symbol { get; set; }
        public string Color { get; set; }
        public string BorderColor { get; set; }

        // Description du contenu de la case, classé par catégorie
        [NotMapped]
        public Dictionary<string, Dictionary<string, string>> Assets
        {
            get { return _jsonAssets == null ? null : JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(_jsonAssets); }
            set { _jsonAssets = JsonSerializer.Serialize(value); }
        }
        [JsonIgnore]
        public string _jsonAssets { get; set; }

        // Les paramètres d'actions exécutables depuis cette case
        [NotMapped]
        public Dictionary<string, string> Parameters
        {
            get { return _jsonParameters == null ? null : JsonSerializer.Deserialize<Dictionary<string, string>>(_jsonParameters); }
            set { _jsonParameters = JsonSerializer.Serialize(value); }
        }
        [JsonIgnore]
        public string _jsonParameters { get; set; }

        // Carte à laquelle la case appartient
        public long MapId { get; set; }
        [JsonIgnore]
        public Map Map { get; set; }
    }
}
