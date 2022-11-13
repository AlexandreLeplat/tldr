﻿using System;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Message
    {
        public long Id { get; set; }

        // Objet du message
        public string Subject { get; set; }

        // Contenu du message
        public string Body { get; set; }

        // Flag indiquant si le message est une notification du système de jeu
        public bool IsNotification { get; set; }

        // Numéro de tour de la notification
        public int Turn { get; set; }

        // Flag indiquant si le message est lu
        public bool IsRead { get; set; }

        // Flag indiquant si le message est archivé
        public bool IsArchived { get; set; }

        // Flag indiquant si le message est supprimé
        public bool IsDeleted { get; set; }

        // Flag indiquant si le message est supprimé de la boîte d'envoi
        public bool IsDeletedForSender { get; set; }

        // Date d'envoi du message
        public DateTime? SendDate { get; set; }

        // Précédent message de la conversation
        public long? PreviousMessageId { get; set; }

        // Joueur auquel le message est adressé
        public long PlayerId { get; set; }
        [JsonIgnore]
        public Player Player { get; set; }

        // Expéditeur du message
        public long SenderId { get; set; }
        [JsonIgnore]
        public Player Sender { get; set; }
    }
}
