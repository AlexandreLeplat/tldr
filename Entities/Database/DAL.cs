using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Entities.Database
{
    public class DAL : DbContext
    {
        public DAL(DbContextOptions<DAL> options)
            : base(options)
        { }

        public DbSet<Spell> ActionTypes { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<MapTile> MapTiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PlayerAction> Actions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>().Property(o => o._jsonAssets).HasColumnName("Assets");
            modelBuilder.Entity<Campaign>().HasOne(c => c.Creator).WithMany(u => u.Campaigns).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Campaign>().HasData(new Campaign()
            {
                Id = 1,
                Name = "La bataille des Quatre Vents",
                CurrentTurn = 1,
                NextTurn = DateTime.MaxValue,
                Status = CampaignStatus.Running,
                Assets = new Dictionary<string, Dictionary<string, string>>()
                    {
                        { "Prochain classement", new Dictionary<string, string> () {{"Tour 3", "" } } }
                    }
            }); ;

            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Name = "Admin", Password = "$2a$11$BjZvEi2T4jXl.dONfcedm.Ll0sL6d226qBIxR.PT0G1LwLk6jJmQO", Role = UserRole.Admin }
                                              , new User() { Id = 2, Name = "toutétékalculé", Password = "$2a$11$yePEmRHE5RMu0lOXIxzt9.Z9sIda516qP3uICCmR2OVizTTDExVXi", Role = UserRole.None }
                                              , new User() { Id = 3, Name = "Elostirion ", Password = "$2a$11$9nUwVLN8btVzPvLZAnUWDeFjMaUxzmfZH6TXjLFsPRMhXeeryXUOu", Role = UserRole.None }
                                              , new User() { Id = 4, Name = "Akodostef", Password = "$2a$11$jA8Nys/YYvA7EKVqNTgYzeUREtgvklcFtrY2kBEoD7VdG9IUAayyO", Role = UserRole.None }
                                              , new User() { Id = 5, Name = "Crabi", Password = "$2a$11$H9XVGihkqHDssIMjGZW9NefJoocnv2y6NJ4PwVEIEosyp2QnjgQMy", Role = UserRole.None });

            modelBuilder.Entity<Player>().Property(o => o._jsonAssets).HasColumnName("Assets");
            modelBuilder.Entity<Player>().HasData(
                new Player() 
                { Id = 1, Name = "Neutre", UserId = 1, CampaignId = 1, IsCurrentPlayer = true, IsAdmin = true, Color = "lightgrey" },
                new Player()
                {
                    Id = 2,
                    Name = "Matsu Kiperuganyu",
                    UserId = 2,
                    CampaignId = 1,
                    IsCurrentPlayer = true,
                    Color = "gold",
                },
                new Player()
                {
                    Id = 3,
                    Name = "Doji Ujitsu",
                    UserId = 3,
                    CampaignId = 1,
                    IsCurrentPlayer = true,
                    Color = "cyan",
                }
                , new Player()
                {
                    Id = 4,
                    Name = "Akodo Yama",
                    UserId = 4,
                    CampaignId = 1,
                    IsCurrentPlayer = true,
                    Color = "yellow",
                }
                , new Player()
                {
                    Id = 5,
                    Name = "Togashi Atsu",
                    UserId = 5,
                    CampaignId = 1,
                    IsCurrentPlayer = true,
                    Color = "green",
                    Assets = new Dictionary<string, Dictionary<string, string>>()
                    {
                        { "Caractéristiques", new Dictionary<string, string> () {{"Gloire", "5"}, { "Infamie", "0" } } },
                        { "Ressources", new Dictionary<string, string> () {{"Stratégie", "5"}, { "Influence", "0" } } }
                    }
                });

            modelBuilder.Entity<Spell>().Property(o => o._jsonForm).HasColumnName("Form");
            modelBuilder.Entity<Spell>().HasData(new Spell()
            {
                Id = 1,
                Label = "Planification",
                Description = "Gagnez un point de Stratégie",
            },
                new Spell()
                {
                    Id = 2,
                    Label = "Flatterie",
                    Description = "Gagnez 1 point de Gloire et faites-en gagner 1 à un adversaire",
                },
                new Spell()
                {
                    Id = 3,
                    Label = "Médisance",
                    Description = "Infligez 3 points d’Infamie à un adversaire et gagnez-en vous-même un point",
                },
                new Spell()
                {
                    Id = 4,
                    Label = "Renforts",
                    Description = "Déployez une armée pour 4 points de Stratégie sur un point d'entrée, 5 sur un bâtiment militaire ou 6 sur un Village",
                },
                new Spell()
                {
                    Id = 5,
                    Label = "Déplacement",
                    Description = "Déplacez une armée d'une case",
                },
                new Spell()
                {
                    Id = 6,
                    Label = "Formation",
                    Description = "Changez la formation de l'armée",
                },
                new Spell()
                {
                    Id = 7,
                    Label = "Renseignements",
                    Description = "Subissez un point d'Infamie pour espionner un adversaire",
                },
                new Spell()
                {
                    Id = 8,
                    Label = "Commerce",
                    Description = "Achetez un point d'Influence pour 4 points de Stratégie et 1 d'Infamie",
                });

            modelBuilder.Entity<PlayerAction>().Property(o => o._jsonParameters).HasColumnName("Parameters");
            modelBuilder.Entity<PlayerAction>().HasOne(e => e.ActionType).WithMany(e => e.Orders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Map>().HasOne(m => m.Player).WithMany(p => p.Maps).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MapTile>().Property(o => o._jsonAssets).HasColumnName("Assets");
            modelBuilder.Entity<Unit>().HasOne(m => m.Player).WithMany(p => p.Units).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Unit>().Property(o => o._jsonAssets).HasColumnName("Assets");
            modelBuilder.Entity<Message>().HasOne(m => m.Sender).WithMany(p => p.Messages).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
