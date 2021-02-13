using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    struct weapon
    {
        public string Name;
        public int Shots;
        public int ShieldPenetration;
        public int ShieldDamage;
        public int HullDamage;
        public int CrewDamage;
        public int SystemDamage;
        public int BreachChance;
        public int FireChance;
        public int Speed;
        public int ChargeRate;
        public int Energy;
        public int Cost;
        public bool Ammo;
    }
    weapon[] weapons;
    void Start()
    {
        weapons = new weapon[100];
        for (int i = 0; i < 100; i++)
        {
            weapons[i].Name = "Missing Weapon Stat";
            weapons[i].Shots = 0;
            weapons[i].ShieldPenetration = 0;
            weapons[i].ShieldDamage = 0;
            weapons[i].HullDamage = 0;
            weapons[i].CrewDamage = 0;
            weapons[i].SystemDamage = 0;
            weapons[i].BreachChance = 0;
            weapons[i].FireChance = 0;
            weapons[i].Speed = 0;
            weapons[i].ChargeRate = 1;
            weapons[i].Energy = 0;
            weapons[i].Cost = 0;
            weapons[i].Ammo = false;
        }

        //Misc

        weapons[0].Name = "No Weapon";
        weapons[0].Shots = 0;
        weapons[0].ShieldPenetration = 0;
        weapons[0].ShieldDamage = 0;
        weapons[0].HullDamage = 0;
        weapons[0].CrewDamage = 0;
        weapons[0].SystemDamage = 0;
        weapons[0].BreachChance = 0;
        weapons[0].FireChance = 0;
        weapons[0].Speed = 0;
        weapons[0].ChargeRate = 1;
        weapons[0].Energy = 0;
        weapons[0].Cost = 0;
        weapons[0].Ammo = false;
        weapons[1].Name = "Test Weapon";
        weapons[1].Shots = 1;
        weapons[1].ShieldPenetration = 0;
        weapons[1].ShieldDamage = 1;
        weapons[1].HullDamage = 1;
        weapons[1].CrewDamage = 40;
        weapons[1].SystemDamage = 1;
        weapons[1].BreachChance = 0;
        weapons[1].FireChance = 0;
        weapons[1].Speed = 10;
        weapons[1].ChargeRate = 3;
        weapons[1].Energy = 1;
        weapons[1].Cost = 1;
        weapons[1].Ammo = false;

        //Lasers

        for (int i = 2; i <= 13; i++)
            weapons[i].Ammo = false;
        weapons[2].Name = "Basic Laser";
        weapons[2].Shots = 1;
        weapons[2].ShieldPenetration = 0;
        weapons[2].ShieldDamage = 1;
        weapons[2].HullDamage = 1;
        weapons[2].CrewDamage = 5;
        weapons[2].SystemDamage = 1;
        weapons[2].BreachChance = 0;
        weapons[2].FireChance = 10;
        weapons[2].Speed = 15;
        weapons[2].ChargeRate = 10;
        weapons[2].Energy = 1;
        weapons[2].Cost = 20;
        weapons[3].Name = "Burst Laser I";
        weapons[3].Shots = 2;
        weapons[3].ShieldPenetration = 0;
        weapons[3].ShieldDamage = 1;
        weapons[3].HullDamage = 1;
        weapons[3].CrewDamage = 5;
        weapons[3].SystemDamage = 1;
        weapons[3].BreachChance = 0;
        weapons[3].FireChance = 10;
        weapons[3].Speed = 15;
        weapons[3].ChargeRate = 11;
        weapons[3].Energy = 2;
        weapons[3].Cost = 50;
        weapons[4].Name = "Burst Laser II";
        weapons[4].Shots = 3;
        weapons[4].ShieldPenetration = 0;
        weapons[4].ShieldDamage = 1;
        weapons[4].HullDamage = 1;
        weapons[4].CrewDamage = 5;
        weapons[4].SystemDamage = 1;
        weapons[4].BreachChance = 0;
        weapons[4].FireChance = 10;
        weapons[4].Speed = 15;
        weapons[4].ChargeRate = 12;
        weapons[4].Energy = 2;
        weapons[4].Cost = 80;
        weapons[5].Name = "Burst Laser III";
        weapons[5].Shots = 5;
        weapons[5].ShieldPenetration = 0;
        weapons[5].ShieldDamage = 1;
        weapons[5].HullDamage = 1;
        weapons[5].CrewDamage = 5;
        weapons[5].SystemDamage = 1;
        weapons[5].BreachChance = 0;
        weapons[5].FireChance = 0;
        weapons[5].Speed = 15;
        weapons[5].ChargeRate = 19;
        weapons[5].Energy = 4;
        weapons[5].Cost = 95;
        weapons[6].Name = "Piercing Laser I";
        weapons[6].Shots = 1;
        weapons[6].ShieldPenetration = 1;
        weapons[6].ShieldDamage = 1;
        weapons[6].HullDamage = 1;
        weapons[6].CrewDamage = 5;
        weapons[6].SystemDamage = 1;
        weapons[6].BreachChance = 20;
        weapons[6].FireChance = 20;
        weapons[6].Speed = 12;
        weapons[6].ChargeRate = 10;
        weapons[6].Energy = 1;
        weapons[6].Cost = 55;
        weapons[7].Name = "Piercing Laser II";
        weapons[7].Shots = 1;
        weapons[7].ShieldPenetration = 2;
        weapons[7].ShieldDamage = 1;
        weapons[7].HullDamage = 2;
        weapons[7].CrewDamage = 5;
        weapons[7].SystemDamage = 1;
        weapons[7].BreachChance = 30;
        weapons[7].FireChance = 30;
        weapons[7].Speed = 12;
        weapons[7].ChargeRate = 14;
        weapons[7].Energy = 3;
        weapons[7].Cost = 70;
        weapons[8].Name = "A.Shield Laser I";
        weapons[8].Shots = 1;
        weapons[8].ShieldPenetration = 0;
        weapons[8].ShieldDamage = 2;
        weapons[8].HullDamage = 0;
        weapons[8].CrewDamage = 0;
        weapons[8].SystemDamage = 0;
        weapons[8].BreachChance = 0;
        weapons[8].FireChance = 0;
        weapons[8].Speed = 14;
        weapons[8].ChargeRate = 17;
        weapons[8].Energy = 3;
        weapons[8].Cost = 60;
        weapons[9].Name = "A.Shield Laser II";
        weapons[9].Shots = 1;
        weapons[9].ShieldPenetration = 0;
        weapons[9].ShieldDamage = 4;
        weapons[9].HullDamage = 0;
        weapons[9].CrewDamage = 0;
        weapons[9].SystemDamage = 0;
        weapons[9].BreachChance = 0;
        weapons[9].FireChance = 0;
        weapons[9].Speed = 14;
        weapons[9].ChargeRate = 21;
        weapons[9].Energy = 4;
        weapons[9].Cost = 100;
        weapons[10].Name = "Heavy Laser I";
        weapons[10].Shots = 1;
        weapons[10].ShieldPenetration = 0;
        weapons[10].ShieldDamage = 1;
        weapons[10].HullDamage = 2;
        weapons[10].CrewDamage = 5;
        weapons[10].SystemDamage = 2;
        weapons[10].BreachChance = 30;
        weapons[10].FireChance = 30;
        weapons[10].Speed = 12;
        weapons[10].ChargeRate = 9;
        weapons[10].Energy = 1;
        weapons[10].Cost = 50;
        weapons[11].Name = "Heavy Laser II";
        weapons[11].Shots = 2;
        weapons[11].ShieldPenetration = 0;
        weapons[11].ShieldDamage = 1;
        weapons[11].HullDamage = 2;
        weapons[11].CrewDamage = 5;
        weapons[11].SystemDamage = 2;
        weapons[11].BreachChance = 30;
        weapons[11].FireChance = 30;
        weapons[11].Speed = 12;
        weapons[11].ChargeRate = 12;
        weapons[11].Energy = 3;
        weapons[11].Cost = 65;
        weapons[12].Name = "A.Hull Laser I";
        weapons[12].Shots = 1;
        weapons[12].ShieldPenetration = 0;
        weapons[12].ShieldDamage = 1;
        weapons[12].HullDamage = 2;
        weapons[12].CrewDamage = 1;
        weapons[12].SystemDamage = 0;
        weapons[12].BreachChance = 20;
        weapons[12].FireChance = 0;
        weapons[12].Speed = 12;
        weapons[12].ChargeRate = 14;
        weapons[12].Energy = 2;
        weapons[12].Cost = 55;
        weapons[13].Name = "A.Hull Laser II";
        weapons[13].Shots = 1;
        weapons[13].ShieldPenetration = 0;
        weapons[13].ShieldDamage = 1;
        weapons[13].HullDamage = 3;
        weapons[13].CrewDamage = 1;
        weapons[13].SystemDamage = 0;
        weapons[13].BreachChance = 30;
        weapons[13].FireChance = 10;
        weapons[13].Speed = 12;
        weapons[13].ChargeRate = 15;
        weapons[13].Energy = 3;
        weapons[13].Cost = 75;

        //Ballistic

        for (int i = 14; i <= 19; i++)
            weapons[i].Ammo = true;
        weapons[14].Name = "Leto Missile";
        weapons[14].Shots = 1;
        weapons[14].ShieldPenetration = 4;
        weapons[14].ShieldDamage = 0;
        weapons[14].HullDamage = 1;
        weapons[14].CrewDamage = 7;
        weapons[14].SystemDamage = 1;
        weapons[14].BreachChance = 10;
        weapons[14].FireChance = 10;
        weapons[14].Speed = 8;
        weapons[14].ChargeRate = 9;
        weapons[14].Energy = 1;
        weapons[14].Cost = 20;
        weapons[15].Name = "Artemis Missile";
        weapons[15].Shots = 1;
        weapons[15].ShieldPenetration = 4;
        weapons[15].ShieldDamage = 0;
        weapons[15].HullDamage = 2;
        weapons[15].CrewDamage = 7;
        weapons[15].SystemDamage = 2;
        weapons[15].BreachChance = 10;
        weapons[15].FireChance = 10;
        weapons[15].Speed = 8;
        weapons[15].ChargeRate = 10;
        weapons[15].Energy = 2;
        weapons[15].Cost = 38;
        weapons[16].Name = "Hermes Missile";
        weapons[16].Shots = 1;
        weapons[16].ShieldPenetration = 4;
        weapons[16].ShieldDamage = 0;
        weapons[16].HullDamage = 3;
        weapons[16].CrewDamage = 7;
        weapons[16].SystemDamage = 3;
        weapons[16].BreachChance = 10;
        weapons[16].FireChance = 10;
        weapons[16].Speed = 8;
        weapons[16].ChargeRate = 14;
        weapons[16].Energy = 3;
        weapons[16].Cost = 45;
        weapons[17].Name = "Breach Missile";
        weapons[17].Shots = 1;
        weapons[17].ShieldPenetration = 4;
        weapons[17].ShieldDamage = 0;
        weapons[17].HullDamage = 4;
        weapons[17].CrewDamage = 7;
        weapons[17].SystemDamage = 4;
        weapons[17].BreachChance = 70;
        weapons[17].FireChance = 10;
        weapons[17].Speed = 8;
        weapons[17].ChargeRate = 22;
        weapons[17].Energy = 3;
        weapons[17].Cost = 65;
        weapons[18].Name = "Hull Missile";
        weapons[18].Shots = 1;
        weapons[18].ShieldPenetration = 4;
        weapons[18].ShieldDamage = 0;
        weapons[18].HullDamage = 4;
        weapons[18].CrewDamage = 7;
        weapons[18].SystemDamage = 2;
        weapons[18].BreachChance = 40;
        weapons[18].FireChance = 10;
        weapons[18].Speed = 8;
        weapons[18].ChargeRate = 17;
        weapons[18].Energy = 2;
        weapons[18].Cost = 65;
        weapons[19].Name = "Pegasus Missile";
        weapons[19].Shots = 2;
        weapons[19].ShieldPenetration = 4;
        weapons[19].ShieldDamage = 0;
        weapons[19].HullDamage = 2;
        weapons[19].CrewDamage = 7;
        weapons[19].SystemDamage = 2;
        weapons[19].BreachChance = 10;
        weapons[19].FireChance = 10;
        weapons[19].Speed = 8;
        weapons[19].ChargeRate = 20;
        weapons[19].Energy = 3;
        weapons[19].Cost = 60;
    }
    public string _GetWeaponName(int number)
    {
        return (weapons[number].Name);
    }
    public int _GetWeaponShots(int number)
    {
        return (weapons[number].Shots);
    }
    public int _GetWeaponShieldPenetration(int number)
    {
        return (weapons[number].ShieldPenetration);
    }
    public int _GetWeaponShieldDamage(int number)
    {
        return (weapons[number].ShieldDamage);
    }
    public int _GetWeaponHullDamage(int number)
    {
        return (weapons[number].HullDamage);
    }
    public int _GetWeaponCrewDamage(int number)
    {
        return (weapons[number].CrewDamage);
    }
    public int _GetWeaponSystemDamage(int number)
    {
        return (weapons[number].SystemDamage);
    }
    public int _GetWeaponBreachChance(int number)
    {
        return (weapons[number].BreachChance);
    }
    public int _GetWeaponFireChance(int number)
    {
        return (weapons[number].FireChance);
    }
    public int _GetWeaponSpeed(int number)
    {
        return (weapons[number].Speed);
    }
    public int _GetWeaponChargeRate(int number)
    {
        return (weapons[number].ChargeRate);
    }
    public int _GetWeaponEnergy(int number)
    {
        return (weapons[number].Energy);
    }
    public int _GetWeaponCost(int number)
    {
        return (weapons[number].Cost);
    }
    public bool _GetWeaponAmmo(int number)
    {
        return (weapons[number].Ammo);
    }
}
