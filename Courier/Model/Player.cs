using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Courier.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CourierClassEnum
    {
        Runner,
        Hacker,
        Tank
    }

    internal class Player
    {
        public string Name { get; set; }
        public CourierClassEnum Class { get; set; }
        public string Icon { get; set; }

        public double Health { get; set; }
        public double Attack { get; set; }
        public double Armor { get; set; }

        [JsonIgnore]
        public double CurrentHealth { get; set; }

        [JsonIgnore]
        public double CurrentAttack { get; set; }

        [JsonIgnore]
        public double CurrentArmor { get; set; }

        [JsonIgnore]
        public double TotalAttack =>
            CurrentAttack + (EquippedWeapon?.Value ?? 0);

        [JsonIgnore]
        public double TotalArmor =>
            CurrentArmor + (EquippedArmor?.Value ?? 0);

        public int CurrentRoom { get; set; }
        public int CurrentBuilding { get; set; }
        public bool HasPackage { get; set; }

        public double EvadeChance { get; set; }
        public double HackSkill { get; set; }
        public double CritChance { get; set; }

        public List<Item> Items { get; set; } = new();

        [JsonIgnore]
        public Item EquippedWeapon { get; set; }

        [JsonIgnore]
        public Item EquippedArmor { get; set; }

        public void ResetToBase()
        {
            CurrentHealth = Health;
            CurrentAttack = Attack;
            CurrentArmor = Armor;
        }
    }
}