using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy_Ship : MonoBehaviour
{
    public GameObject EnemyProjectile;
	public Sprite PowerBarOn;
	public Sprite PowerBarOff;
	public Sprite Nothing;
	public Sprite ShieldOn;
	public Sprite ShieldOff;
	public Sprite MissingTexture;
	public Sprite HullHp1;
	public Sprite HullHp2;
	public Sprite HullHp3;
	public Sprite HullHp4;
	public Sprite HullHp5;
	public Sprite HullHp6;
	public Sprite HullHp7;
	public Sprite HullHp8;
	public Sprite HullHp9;
	public Sprite HullHp10;
	public Sprite HullHp11;
	public Sprite HullHp12;
	public Sprite HullHp13;
	public Sprite HullHp14;
	public Sprite HullHp15;
	public Sprite HullHp16;
	public Sprite HullHp17;
	public Sprite HullHp18;
	public Sprite HullHp19;
	public Sprite HullHp20;
	public Sprite HullHp21;
	public Sprite HullHp22;
	public Sprite HullHp23;
	public Sprite HullHp24;
	public Sprite HullHp25;
	public Sprite HullHp26;
	public Sprite HullHp27;
	public Sprite HullHp28;
	public Sprite HullHp29;
	public Sprite HullHp30;

    float ShieldRegenRate = 3f;

    int HullHp = 0;
    int ShieldMax = 0;
    int Shield = 0;
    int Ammo = 0;
    int DronePart = 0;
    float Evade = 0;
    int Oxygen = 100;

    int Energy = 0;
    int EnergyMax = 0;

    int ShieldEnergy = 0;
    int EngineEnergy = 0;
    int OxygenEnergy = 0;
    int MedbayEnergy = 0;
    int WeaponEnergy = 0;
    int CloakEnergy = 0;
    int ShieldEnergyMax = 0;
    int EngineEnergyMax = 0;
    int OxygenEnergyMax = 0;
    int MedbayEnergyMax = 0;
    int WeaponEnergyMax = 0;
    int CockpitEnergyMax = 0;
    int DoorEnergyMax = 0;
    int SensorEnergyMax = 0;
    int CloakEnergyMax = 0;
    int ShieldEnergyDamaged = 0;
    int EngineEnergyDamaged = 0;
    int OxygenEnergyDamaged = 0;
    int MedbayEnergyDamaged = 0;
    int WeaponEnergyDamaged = 0;
    int CockpitEnergyDamaged = 0;
    int DoorEnergyDamaged = 0;
    int SensorEnergyDamaged = 0;
    int CloakEnergyDamaged = 0;

    int ShieldCrew = 0;
    int EngineCrew = 0;
    int OxygenCrew = 0;
    int MedbayCrew = 0;
    int WeaponCrew = 0;
    int CockpitCrew = 0;
    int DoorCrew = 0;
    int SensorCrew = 0;
    int CloakCrew = 0;

    bool Weapon1Powered = false;
    bool Weapon2Powered = false;
    bool Weapon3Powered = false;
    bool Weapon4Powered = false;
    int Weapon1ID = 0;
    int Weapon2ID = 0;
    int Weapon3ID = 0;
    int Weapon4ID = 0;
    int Weapon1Percent = 0;
    int Weapon2Percent = 0;
    int Weapon3Percent = 0;
    int Weapon4Percent = 0;

    float RepairRate = 10f;

    int PlayerSensor = 0;

    int ShipWidth;
    int ShipHeight;

    int selected = 0;                                   //selected crew
    int rooms = 0;                                      //total number of rooms
    int w, h;                                           //width+3, height+3
    ship_properties[,] ship;                            //ship[wall_x, wall_y, property]
    weapon[] weapons;

    struct ship_properties
    {
        public bool room;
        public bool breach;
        public bool wall_left;
        public bool wall_top;
        public bool wall_right;
        public bool wall_bottom;
        public bool door_left;
        public bool door_top;
        public bool door_right;
        public bool door_bottom;
        public int crew;
        public int crew_target;
        public int fire;
        public float oxigen;
        public int space;
        public int path;
        public float x;
        public float y;
        public string role;
    }
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

    //initialize

    public void InitializeWalls(int a, int b, string orientation)   //initialize walls
    {
        switch (orientation)
        {
            case "left":
                ship[a, b].wall_left = true;
                ship[a, b].door_left = true;
                break;
            case "top":
                ship[a, b].wall_top = true;
                ship[a, b].door_top = true;
                break;
            case "right":
                ship[a, b].wall_right = true;
                ship[a, b].door_right = true;
                break;
            case "bottom":
                ship[a, b].wall_bottom = true;
                ship[a, b].door_bottom = true;
                break;
        }
    }
    public void InitializeDoors()                                   //initialize doors
    {
        int x, y, orientation;
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).tag == "Door")
            {
                x = int.Parse(transform.GetChild(i).name.Remove(0, 4).Remove(2, 6));
                y = int.Parse(transform.GetChild(i).name.Remove(0, 7).Remove(2, 3));
                orientation = int.Parse(transform.GetChild(i).name.Remove(0, 10));
                switch (orientation)
                {
                    case 1:         //vertical
                        ship[x, y].wall_left = false;
                        ship[x - 1, y].wall_right = false;
                        break;
                    case 2:         //horizontal
                        ship[x, y].wall_top = false;
                        ship[x, y - 1].wall_bottom = false;
                        break;
                }
            }
        }
    }
    public void InitializeStats(int E, int ES, int EE, int EO, int EM, int EW, int EC, int EsC, int EsD, int EsS, int W1, int W2, int W3, int W4, int Am, int Hp, string Name)
    {
        EnergyMax = E;
        Energy = EnergyMax;
        ShieldEnergyMax = ES;
        EngineEnergyMax = EE;
        OxygenEnergyMax = EO;
        MedbayEnergyMax = EM;
        WeaponEnergyMax = EW;
        CockpitEnergyMax = EsC;
        DoorEnergyMax = EsD;
        SensorEnergyMax = EsS;
        CloakEnergyMax = EC;
        if (CloakEnergyMax == 0)
            GameObject.Find("EnemyUI").transform.Find("IconCloak").gameObject.SetActive(false);

        Weapon1ID = W1;
        Weapon2ID = W2;
        Weapon3ID = W3;
        Weapon4ID = W4;

        Ammo = Am;

		HullHp = Hp;

        GameObject.Find("EnemyUI").transform.Find("Name").GetComponent<Text>().text = Name;
    }
    public void Initialize(int a, int b)
    {
        PlayerSensor = GameObject.Find("Ship").GetComponent<Ship>()._PlayerSensor();
        ship = new ship_properties[a, b];               //initialize ship size (a width+3, b height+3)
        ShipWidth = a;
        ShipHeight = b;
        w = a - 1;                                      //with+2
        h = b - 1;                                      //heght+2
        for (int i = 1; i <= w; i++)                        //initialize ship propertys
        {
            for (int j = 1; j <= h; j++)
            {
                ship[i, j].room = false;
                ship[i, j].breach = false;
                ship[i, j].wall_left = false;
                ship[i, j].wall_top = false;
                ship[i, j].wall_right = false;
                ship[i, j].wall_bottom = false;
                ship[i, j].door_left = false;
                ship[i, j].door_top = false;
                ship[i, j].door_right = false;
                ship[i, j].door_bottom = false;
                ship[i, j].crew = 0;
                ship[i, j].crew_target = 0;
                ship[i, j].fire = 0;
                ship[i, j].oxigen = 100;
                ship[i, j].space = 0;
                ship[i, j].path = 0;
                ship[i, j].x = 0;
                ship[i, j].y = 0;
            }
        }
        int x, y;                                       //initialize ship rooms
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {                                               //find rooms in children
            if (transform.GetChild(i).name.Contains("room"))
            {
                x = int.Parse(transform.GetChild(i).name.Remove(0, 4).Remove(2, 3));
                y = int.Parse(transform.GetChild(i).name.Remove(0, 7));
                ship[x, y].room = true;
                ship[x, y].x = transform.GetChild(i).transform.localPosition.x;
                ship[x, y].y = transform.GetChild(i).transform.localPosition.y;
                rooms++;
            }
        }
        StartCoroutine(OxygenSys());                        //oxigen system
        HullHpChange();
        EnergyChange();
        CockpitEnergyChange();
        DoorEnergyChange();
        SensorEnergyChange();
        CloakEnergyChange();
        ShieldChange();

        weapons = new weapon[100];
        for (int i = 0; i < 100; i++)
        {
            weapons[i].Name = Camera.main.GetComponent<Stats>()._GetWeaponName(i);
            weapons[i].Shots = Camera.main.GetComponent<Stats>()._GetWeaponShots(i);
            weapons[i].ShieldPenetration = Camera.main.GetComponent<Stats>()._GetWeaponShieldPenetration(i);
            weapons[i].ShieldDamage = Camera.main.GetComponent<Stats>()._GetWeaponShieldDamage(i);
            weapons[i].HullDamage = Camera.main.GetComponent<Stats>()._GetWeaponHullDamage(i);
            weapons[i].CrewDamage = Camera.main.GetComponent<Stats>()._GetWeaponCrewDamage(i);
            weapons[i].SystemDamage = Camera.main.GetComponent<Stats>()._GetWeaponSystemDamage(i);
            weapons[i].BreachChance = Camera.main.GetComponent<Stats>()._GetWeaponBreachChance(i);
            weapons[i].FireChance = Camera.main.GetComponent<Stats>()._GetWeaponFireChance(i);
            weapons[i].Speed = Camera.main.GetComponent<Stats>()._GetWeaponSpeed(i);
            weapons[i].ChargeRate = Camera.main.GetComponent<Stats>()._GetWeaponChargeRate(i);
            weapons[i].Energy = Camera.main.GetComponent<Stats>()._GetWeaponEnergy(i);
            weapons[i].Cost = Camera.main.GetComponent<Stats>()._GetWeaponCost(i);
            weapons[i].Ammo = Camera.main.GetComponent<Stats>()._GetWeaponAmmo(i);
        }
        WeaponChange();
        if (Weapon1Powered)
            StartCoroutine(Weapon1Charge());
        if (Weapon2Powered)
            StartCoroutine(Weapon2Charge());
        if (Weapon3Powered)
            StartCoroutine(Weapon3Charge());
        if (Weapon4Powered)
            StartCoroutine(Weapon4Charge());
        StartCoroutine(InitializeAI());
        StartCoroutine(AI());
        GameObject.Find("EnemyUI").transform.Find("IconShield").transform.Find("ShieldRepairPercent").GetComponent<Text>().text = ("");
        GameObject.Find("EnemyUI").transform.Find("IconEngine").transform.Find("EngineRepairPercent").GetComponent<Text>().text = ("");
        GameObject.Find("EnemyUI").transform.Find("IconOxygen").transform.Find("OxygenRepairPercent").GetComponent<Text>().text = ("");
        GameObject.Find("EnemyUI").transform.Find("IconMedbay").transform.Find("MedbayRepairPercent").GetComponent<Text>().text = ("");
        GameObject.Find("EnemyUI").transform.Find("IconWeapon").transform.Find("WeaponRepairPercent").GetComponent<Text>().text = ("");
        GameObject.Find("EnemyUI").transform.Find("IconCockpit").transform.Find("CockpitRepairPercent").GetComponent<Text>().text = ("");
        GameObject.Find("EnemyUI").transform.Find("IconDoor").transform.Find("DoorRepairPercent").GetComponent<Text>().text = ("");
        GameObject.Find("EnemyUI").transform.Find("IconSensor").transform.Find("SensorRepairPercent").GetComponent<Text>().text = ("");
    }

    //ship

    void SpaceChange()                                  //oxigen sub system
    {
        int temp1, temp2, temp3, temp4;             //store some values until comparing them
        for (int i = 2; i <= w - 1; i++)                    //write everithing to 0
        {
            for (int j = 2; j <= h - 1; j++)
            {
                ship[i, j].space = 0;
            }
        }
        for (int k = 1; k <= w + h - 2; k++)                //maximal refresh times (w+h-1)
        {
            for (int i = 2; i <= w - 1; i++)                //refresh all rooms
            {
                for (int j = 2; j <= h - 1; j++)
                {
                    if (ship[i, j].room)            //if room present
                    {
                        temp1 = 0;
                        temp2 = 0;
                        temp3 = 0;
                        temp4 = 0;                      //if breach or outer space contact, add vacum
                        if (ship[i, j].breach | (!ship[i, j].door_left & !ship[i - 1, j].room) | (!ship[i, j].door_top & !ship[i, j - 1].room) | (!ship[i, j].door_right & !ship[i + 1, j].room) | (!ship[i, j].door_bottom & !ship[i, j + 1].room))
                        {
                            ship[i, j].space = 100;
                        }                               //if vacume in next room, add vacum
                        if (ship[i - 1, j].space > ship[i, j].space & !ship[i, j].door_left)
                        {
                            temp1 = ship[i - 1, j].space - 1;
                        }
                        if (ship[i, j - 1].space > ship[i, j].space & !ship[i, j].door_top)
                        {
                            temp2 = ship[i, j - 1].space - 1;
                        }
                        if (ship[i + 1, j].space > ship[i, j].space & !ship[i, j].door_right)
                        {
                            temp3 = ship[i + 1, j].space - 1;
                        }
                        if (ship[i, j + 1].space > ship[i, j].space & !ship[i, j].door_bottom)
                        {
                            temp4 = ship[i, j + 1].space - 1;
                        }                               //compare values
                        if (temp1 >= temp2 & temp1 >= temp3 & temp1 >= temp4 & temp1 != 0)
                        {
                            ship[i, j].space = temp1;
                        }
                        if (temp2 >= temp1 & temp2 >= temp3 & temp2 >= temp4 & temp2 != 0)
                        {
                            ship[i, j].space = temp2;
                        }
                        if (temp3 >= temp2 & temp3 >= temp1 & temp3 >= temp4 & temp3 != 0)
                        {
                            ship[i, j].space = temp3;
                        }
                        if (temp4 >= temp2 & temp4 >= temp3 & temp4 >= temp1 & temp4 != 0)
                        {
                            ship[i, j].space = temp4;
                        }
                    }
                }
            }
        }
    }
    IEnumerator OxygenSys()                             //oxigen system
    {
        string temp1, temp2;                            //shitty object naming solution variables
        int SummOxygen;
        while (true)
        {                                               //refresh all rooms
            SummOxygen = 0;
            for (int i = 2; i <= w - 1; i++)
            {
                for (int j = 2; j <= h - 1; j++)
                {                                       //if room present
                    if (ship[i, j].room)
                    {                                   //if vacum present
                        if (ship[i, j].space != 0)
                        {                               //subtract oxigen
                            ship[i, j].oxigen -= 10;
                        }                               //add oxigen
                        else
                        {   //f(x)=0.0833333x^3 + 0.3x^2 + 1.71667x − 0.5
                            ship[i, j].oxigen += 0.0833333f * (float)Math.Pow(OxygenEnergy, 3) + 0.3f * (float)Math.Pow(OxygenEnergy, 2) + 1.71667f * OxygenEnergy - 0.5f;
                        }
                        if (ship[i, j].oxigen < 0)          //create limit (0-100)
                        {
                            ship[i, j].oxigen = 0;
                        }
                        if (ship[i, j].oxigen > 100)
                        {
                            ship[i, j].oxigen = 100;
                        }                               //shitty object naming solutin
                        if (i >= 10)
                        {
                            temp1 = "room";
                        }
                        else
                        {
                            temp1 = "room0";
                        }
                        if (j >= 10)
                        {
                            temp2 = "_";
                        }
                        else
                        {
                            temp2 = "_0";
                        }                               //change room color
                        gameObject.transform.Find(temp1 + i.ToString() + temp2 + j.ToString()).GetComponent<SpriteRenderer>().color = new Color32((byte)255, (byte)(155 + ship[i, j].oxigen), (byte)(155 + ship[i, j].oxigen), 255);
                        SummOxygen += Convert.ToInt32(ship[i, j].oxigen);
                        if (ship[i, j].crew != 0)
                        {
                            if (ship[i, j].oxigen < 5)
                            {
								gameObject.transform.Find("crew" + ship[i, j].crew.ToString()).GetComponent<Enemy_Crew>().Suffocate(true);
                            }
                            else
                            {
                                gameObject.transform.Find("crew" + ship[i, j].crew.ToString()).GetComponent<Enemy_Crew>().Suffocate(false);
                            }
                        }
                    }
                }
            }                                           //wait half sec
            Oxygen = Convert.ToInt32(SummOxygen / rooms);
            yield return new WaitForSeconds((float)0.5);
        }
    }
    public void CrewChange(int x, int y, int crew, bool state)
    {                                                   //crew status change in room
        if (state)
        {
            ship[x, y].crew = crew;
            switch (ship[x, y].role)
            {
                case "Shield":
                    ShieldCrew++;
                    break;
                case "Engine":
                    EngineCrew++;
                    break;
                case "Oxygen":
                    OxygenCrew++;
                    break;
                case "Medbay":
                    MedbayCrew++;
                    break;
                case "Weapon":
                    WeaponCrew++;
                    break;
                case "Cockpit":
                    CockpitCrew++;
                    break;
                case "Door":
                    DoorCrew++;
                    break;
                case "Sensor":
                    SensorCrew++;
                    break;
                case "Cloak":
                    CloakCrew++;
                    break;
            }
        }
        else
        {
            ship[x, y].crew = 0;
            switch (ship[x, y].role)
            {
                case "Shield":
                    ShieldCrew--;
                    break;
                case "Engine":
                    EngineCrew--;
                    break;
                case "Oxygen":
                    OxygenCrew--;
                    break;
                case "Medbay":
                    MedbayCrew--;
                    break;
                case "Weapon":
                    WeaponCrew--;
                    break;
                case "Cockpit":
                    CockpitCrew--;
                    break;
                case "Door":
                    DoorCrew--;
                    break;
                case "Sensor":
                    SensorCrew++;
                    break;
                case "Cloak":
                    CloakCrew++;
                    break;
            }
        }
    }
    public void Navigate(int x, int y)                  //a room has been clicked
    {
        int a, b;
        if (selected != 0 & ship[x, y].crew == 0 & ship[x, y].crew_target == 0)     //if selected room & no crew present
        {
            int temp1, temp2, temp3, temp4;
            for (int i = 2; i <= w - 1; i++)
            {
                for (int j = 2; j <= h - 1; j++)
                {
                    ship[i, j].path = 0;                //set navigation values to 0
                }
            }
            for (int k = 1; k <= w + h - 2; k++)        //refresh w+h times
            {
                for (int i = 2; i <= w - 1; i++)
                {
                    for (int j = 2; j <= h - 1; j++)
                    {
                        if (ship[i, j].room)            //if room present
                        {
                            temp1 = 0;
                            temp2 = 0;
                            temp3 = 0;
                            temp4 = 0;
                            ship[x, y].path = 100;      //set target room navgation value to 100
                            for (int m = 2; m <= w - 1; m++)
                            {
                                for (int n = 2; n <= h - 1; n++)
                                {
                                    if (ship[m, n].crew_target == selected)
                                        ship[m, n].crew_target = 0;
                                }
                            }
                            ship[x, y].crew_target = selected;
                            if (ship[i - 1, j].path > ship[i, j].path & !ship[i, j].wall_left)
                            {                           //if nav value bigger on left & no left wall present
                                temp1 = ship[i - 1, j].path - 1;
                            }                           //set temp1 to left-1 nav value
                            if (ship[i, j - 1].path > ship[i, j].path & !ship[i, j].wall_top)
                            {                           //if nav value bigger on bottom & bottom left wall present
                                temp2 = ship[i, j - 1].path - 1;
                            }                           //set temp2 to bottom-1 nav value
                            if (ship[i + 1, j].path > ship[i, j].path & !ship[i, j].wall_right)
                            {                           //if nav value bigger on right & right left wall present
                                temp3 = ship[i + 1, j].path - 1;
                            }                           //set temp3 to right-1 nav value
                            if (ship[i, j + 1].path > ship[i, j].path & !ship[i, j].wall_bottom)
                            {                           //if nav value bigger on top & no top wall present
                                temp4 = ship[i, j + 1].path - 1;
                            }                           //set temp4 to top-1 nav value
                            if (temp1 >= temp2 & temp1 >= temp3 & temp1 >= temp4 & temp1 != 0)
                            {
                                ship[i, j].path = temp1;
                            }
                            if (temp2 >= temp1 & temp2 >= temp3 & temp2 >= temp4 & temp2 != 0)
                            {
                                ship[i, j].path = temp2;
                            }
                            if (temp3 >= temp2 & temp3 >= temp1 & temp3 >= temp4 & temp3 != 0)
                            {
                                ship[i, j].path = temp3;
                            }
                            if (temp4 >= temp2 & temp4 >= temp3 & temp4 >= temp1 & temp4 != 0)
                            {
                                ship[i, j].path = temp4;
                            }                           //compare temps & set nav value to the biggest
                        }
                    }
                }
            }
            a = 1;
            b = 1;
            bool crewPresent = false;
            for (int i = 2; i <= w - 1; i++)
            {
                for (int j = 2; j <= h - 1; j++)
                {
                    if (ship[i, j].crew == selected)
                    {
                        a = i;
                        b = j;
                        crewPresent = true;
                    }
                }
            }
            bool begin = true;
            int fos = 0;
            while (ship[a, b].path != 100 & crewPresent & fos < 10000)
            {
                fos++;
                bool got = false;
                int temp = 0;
                if (ship[a - 1, b].path == ship[a, b].path + 1 & !got & !ship[a, b].wall_left)
                {
                    got = true;
                    if (ship[a, b].path != 99 & !begin)
                    {
                        gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a - 1, b].x, ship[a - 1, b].y, false, false);
                    }
                    if (ship[a, b].path == 99 & !begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a - 1, b].x, ship[a - 1, b].y, true, false);
                    }
                    if (ship[a, b].path == 99 & begin)
                    {
                        begin = false;
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a - 1, b].x, ship[a - 1, b].y, true, true);
                    }
                    if (ship[a, b].path != 99 & begin)
                    {
                        begin = false;
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a - 1, b].x, ship[a - 1, b].y, false, true);
                    }
                    temp = 6;
                }
                if (ship[a, b - 1].path == ship[a, b].path + 1 & !got & !ship[a, b].wall_top)
                {
                    got = true;
                    if (ship[a, b].path != 99 & !begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b - 1].x, ship[a, b - 1].y, false, false);
                    }
                    if (ship[a, b].path == 99 & !begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b - 1].x, ship[a, b - 1].y, true, false);
                    }
                    if (ship[a, b].path == 99 & begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b - 1].x, ship[a, b - 1].y, true, true);
                        begin = false;
                    }
                    if (ship[a, b].path != 99 & begin)
                    {
                        begin = false;
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b - 1].x, ship[a, b - 1].y, false, true);
                    }
                    temp = 7;
                }
                if (ship[a + 1, b].path == ship[a, b].path + 1 & !got & !ship[a, b].wall_right)
                {
                    got = true;
                    if (ship[a, b].path != 99 & !begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a + 1, b].x, ship[a + 1, b].y, false, false);
                    }
                    if (ship[a, b].path == 99 & !begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a + 1, b].x, ship[a + 1, b].y, true, false);
                    }
                    if (ship[a, b].path == 99 & begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a + 1, b].x, ship[a + 1, b].y, true, true);
                        begin = false;
                    }
                    if (ship[a, b].path != 99 & begin)
                    {
                        begin = false;
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a + 1, b].x, ship[a + 1, b].y, false, true);
                    }
                    temp = 8;
                }
                if (ship[a, b + 1].path == ship[a, b].path + 1 & !got & !ship[a, b].wall_bottom)
                {
                    got = true;
                    if (ship[a, b].path != 99 & !begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b + 1].x, ship[a, b + 1].y, false, false);
                    }
                    if (ship[a, b].path == 99 & !begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b + 1].x, ship[a, b + 1].y, true, false);
                    }
                    if (ship[a, b].path == 99 & begin)
                    {
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b + 1].x, ship[a, b + 1].y, true, true);
                        begin = false;
                    }
                    if (ship[a, b].path != 99 & begin)
                    {
                        begin = false;
						gameObject.transform.Find("crew" + selected.ToString()).GetComponent<Enemy_Crew>().AddQueue(ship[a, b + 1].x, ship[a, b + 1].y, false, true);
                    }
                    temp = 9;
                }
                switch (temp)
                {
                    case 6:
                        a--;
                        break;
                    case 7:
                        b--;
                        break;
                    case 8:
                        a++;
                        break;
                    case 9:
                        b++;
                        break;
                }
            }
            selected = 0;
        }
    }

    //void Update (key detection)

    void Update()
    {
        if (Shield < ShieldEnergy / 2 & !ShieldRegen)
            StartCoroutine(ShieldCharge());
        if (ShieldEnergyDamaged > 0 & !ShieldRepairing)
            StartCoroutine(ShieldRepair());
        if (EngineEnergyDamaged > 0 & !EngineRepairing)
            StartCoroutine(EngineRepair());
        if (OxygenEnergyDamaged > 0 & !OxygenRepairing)
            StartCoroutine(OxygenRepair());
        if (MedbayEnergyDamaged > 0 & !MedbayRepairing)
            StartCoroutine(MedbayRepair());
        if (WeaponEnergyDamaged > 0 & !WeaponRepairing)
            StartCoroutine(WeaponRepair());
        if (CockpitEnergyDamaged > 0 & !CockpitRepairing)
            StartCoroutine(CockpitRepair());
        if (DoorEnergyDamaged > 0 & !DoorRepairing)
            StartCoroutine(DoorRepair());
        if (SensorEnergyDamaged > 0 & !SensorRepairing)
            StartCoroutine(SensorRepair());
        if (CloakEnergyDamaged > 0 & !CloakRepairing)
            StartCoroutine(CloakRepair());
    }
    bool ShieldRegen = false;
    int ShieldPercent = 0;
    bool ShieldInterrupt = false;
    IEnumerator ShieldCharge()
    {
        ShieldRegen = true;
        ShieldPercent = 0;
        while (ShieldPercent < ShieldRegenRate * 10 & !ShieldInterrupt)
        {
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("ShieldPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(ShieldPercent / (float)ShieldRegenRate * 10, 0)) + "%");
            ShieldPercent++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!ShieldInterrupt)
        {
            Shield++;
            ShieldChange();
        }
        ShieldInterrupt = false;
        ShieldRegen = false;
		GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("ShieldPercent").GetComponent<Text>().text = ("");
    }
    bool ShieldRepairing = false;
    int ShieldRepairPercent = 0;
    IEnumerator ShieldRepair()
    {
        ShieldRepairing = true;
        ShieldRepairPercent = 0;
        while (ShieldRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconShield").transform.Find("ShieldRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(ShieldRepairPercent / (float)RepairRate * 10, 0)) + "%");
            ShieldRepairPercent += ShieldCrew;
            yield return new WaitForSeconds(0.1f);
        }
        ShieldEnergyDamaged--;
        ShieldEnergyMax++;
        ShieldEnergyChange();
        ShieldRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconShield").transform.Find("ShieldRepairPercent").GetComponent<Text>().text = ("");
    }
    bool EngineRepairing = false;
    int EngineRepairPercent = 0;
    IEnumerator EngineRepair()
    {
        EngineRepairing = true;
        EngineRepairPercent = 0;
        while (EngineRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconEngine").transform.Find("EngineRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(EngineRepairPercent / (float)RepairRate * 10, 0)) + "%");
            EngineRepairPercent += EngineCrew;
            //Debug.Log (EngineCrew);
            yield return new WaitForSeconds(0.1f);
        }
        EngineEnergyDamaged--;
        EngineEnergyMax++;
        EngineEnergyChange();
        EngineRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconEngine").transform.Find("EngineRepairPercent").GetComponent<Text>().text = ("");
    }
    bool OxygenRepairing = false;
    int OxygenRepairPercent = 0;
    IEnumerator OxygenRepair()
    {
        OxygenRepairing = true;
        OxygenRepairPercent = 0;
        while (OxygenRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconOxygen").transform.Find("OxygenRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(OxygenRepairPercent / (float)RepairRate * 10, 0)) + "%");
            OxygenRepairPercent += OxygenCrew;
            yield return new WaitForSeconds(0.1f);
        }
        OxygenEnergyDamaged--;
        OxygenEnergyMax++;
        OxygenEnergyChange();
        OxygenRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconOxygen").transform.Find("OxygenRepairPercent").GetComponent<Text>().text = ("");
    }
    bool MedbayRepairing = false;
    int MedbayRepairPercent = 0;
    IEnumerator MedbayRepair()
    {
        MedbayRepairing = true;
        MedbayRepairPercent = 0;
        while (MedbayRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconMedbay").transform.Find("MedbayRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(MedbayRepairPercent / (float)RepairRate * 10, 0)) + "%");
            MedbayRepairPercent += MedbayCrew;
            yield return new WaitForSeconds(0.1f);
        }
        MedbayEnergyDamaged--;
        MedbayEnergyMax++;
        MedbayEnergyChange();
        MedbayRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconMedbay").transform.Find("MedbayRepairPercent").GetComponent<Text>().text = ("");
    }
    bool WeaponRepairing = false;
    int WeaponRepairPercent = 0;
    IEnumerator WeaponRepair()
    {
        WeaponRepairing = true;
        WeaponRepairPercent = 0;
        while (WeaponRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconWeapon").transform.Find("WeaponRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(WeaponRepairPercent / (float)RepairRate * 10, 0)) + "%");
            WeaponRepairPercent += WeaponCrew;
            yield return new WaitForSeconds(0.1f);
        }
        WeaponEnergyDamaged--;
        WeaponEnergyMax++;
        WeaponEnergyChange();
        WeaponRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconWeapon").transform.Find("WeaponRepairPercent").GetComponent<Text>().text = ("");
    }
    bool CockpitRepairing = false;
    int CockpitRepairPercent = 0;
    IEnumerator CockpitRepair()
    {
        CockpitRepairing = true;
        CockpitRepairPercent = 0;
        while (CockpitRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconCockpit").transform.Find("CockpitRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(CockpitRepairPercent / (float)RepairRate * 10, 0)) + "%");
            CockpitRepairPercent += CockpitCrew;
            yield return new WaitForSeconds(0.1f);
        }
        CockpitEnergyDamaged--;
        CockpitEnergyMax++;
        CockpitEnergyChange();
        CockpitRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconCockpit").transform.Find("CockpitRepairPercent").GetComponent<Text>().text = ("");
    }
    bool DoorRepairing = false;
    int DoorRepairPercent = 0;
    IEnumerator DoorRepair()
    {
        DoorRepairing = true;
        DoorRepairPercent = 0;
        while (DoorRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconDoor").transform.Find("DoorRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(DoorRepairPercent / (float)RepairRate * 10, 0)) + "%");
            DoorRepairPercent += DoorCrew;
            yield return new WaitForSeconds(0.1f);
        }
        DoorEnergyDamaged--;
        DoorEnergyMax++;
        DoorEnergyChange();
        DoorRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconDoor").transform.Find("DoorRepairPercent").GetComponent<Text>().text = ("");
    }
    bool SensorRepairing = false;
    int SensorRepairPercent = 0;
    IEnumerator SensorRepair()
    {
        SensorRepairing = true;
        SensorRepairPercent = 0;
        while (SensorRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconSensor").transform.Find("SensorRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(SensorRepairPercent / (float)RepairRate * 10, 0)) + "%");
            SensorRepairPercent += SensorCrew;
            yield return new WaitForSeconds(0.1f);
        }
        SensorEnergyDamaged--;
        SensorEnergyMax++;
        SensorEnergyChange();
        SensorRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconSensor").transform.Find("SensorRepairPercent").GetComponent<Text>().text = ("");
    }
    bool CloakRepairing = false;
    int CloakRepairPercent = 0;
    IEnumerator CloakRepair()
    {
        CloakRepairing = true;
        CloakRepairPercent = 0;
        while (CloakRepairPercent < RepairRate * 10)
        {
			GameObject.Find("EnemyUI").transform.Find("IconCloak").transform.Find("CloakRepairPercent").GetComponent<Text>().text = (Convert.ToString(Math.Round(CloakRepairPercent / (float)RepairRate * 10, 0)) + "%");
            CloakRepairPercent += CloakCrew;
            yield return new WaitForSeconds(0.1f);
        }
        CloakEnergyDamaged--;
        CloakEnergyMax++;
        CloakEnergyChange();
        CloakRepairing = false;
		GameObject.Find("EnemyUI").transform.Find("IconCloak").transform.Find("CloakRepairPercent").GetComponent<Text>().text = ("");
    }
    int Weapon1ChargingPercent = 0;
    IEnumerator Weapon1Charge()
    {
        Weapon1ChargingPercent = 0;
        while (Weapon1ChargingPercent <= weapons[Weapon1ID].ChargeRate * 10 & Weapon1Powered)
        {
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon1").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon1ID].Name + " " + Math.Round(Weapon1ChargingPercent / (float)weapons[Weapon1ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon1").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon1ID].Name));
            Weapon1ChargingPercent++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!Weapon1Powered)
        {
            Weapon1ChargingPercent = 0;
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon1").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon1ID].Name + " " + Math.Round(Weapon1ChargingPercent / (float)weapons[Weapon1ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon1").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon1ID].Name));
        }
    }
    int Weapon2ChargingPercent = 0;
    IEnumerator Weapon2Charge()
    {
        Weapon2ChargingPercent = 0;
        while (Weapon2ChargingPercent <= weapons[Weapon2ID].ChargeRate * 10 & Weapon2Powered)
        {
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon2").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon2ID].Name + " " + Math.Round(Weapon2ChargingPercent / (float)weapons[Weapon2ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon2").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon2ID].Name));
            Weapon2ChargingPercent++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!Weapon2Powered)
        {
            Weapon2ChargingPercent = 0;
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon2").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon2ID].Name + " " + Math.Round(Weapon2ChargingPercent / (float)weapons[Weapon2ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon2").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon2ID].Name));
        }
    }
    int Weapon3ChargingPercent = 0;
    IEnumerator Weapon3Charge()
    {
        Weapon3ChargingPercent = 0;
        while (Weapon3ChargingPercent <= weapons[Weapon3ID].ChargeRate * 10 & Weapon3Powered)
        {
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon3").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon3ID].Name + " " + Math.Round(Weapon3ChargingPercent / (float)weapons[Weapon3ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon3").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon3ID].Name));
            Weapon3ChargingPercent++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!Weapon3Powered)
        {
            Weapon3ChargingPercent = 0;
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon3").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon3ID].Name + " " + Math.Round(Weapon3ChargingPercent / (float)weapons[Weapon3ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon3").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon3ID].Name));
        }
    }
    int Weapon4ChargingPercent = 0;
    IEnumerator Weapon4Charge()
    {
        Weapon4ChargingPercent = 0;
        while (Weapon4ChargingPercent <= weapons[Weapon4ID].ChargeRate * 10 & Weapon4Powered)
        {
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon4").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon4ID].Name + " " + Math.Round(Weapon4ChargingPercent / (float)weapons[Weapon4ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon4").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon4ID].Name));
            Weapon4ChargingPercent++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!Weapon4Powered)
        {
            Weapon4ChargingPercent = 0;
            if (PlayerSensor >= 2)
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon4").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon4ID].Name + " " + Math.Round(Weapon4ChargingPercent / (float)weapons[Weapon4ID].ChargeRate * 10, 0)) + "%");
            else
                GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon4").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon4ID].Name));
        }
    }

    //AI action input

    public void ShieldClicked(bool plus)
	{
        if (!plus & Energy < EnergyMax & ShieldEnergy > 0)
        {
            Energy++;
            ShieldEnergy--;
        }
        if (plus & Energy > 0 & ShieldEnergy < ShieldEnergyMax)
        {
            Energy--;
        	ShieldEnergy++;
        }
        EnergyChange();
    }
	public void EngineClicked(bool plus)
	{
		if (!plus & Energy < EnergyMax & EngineEnergy > 0)
		{
			Energy++;
			EngineEnergy--;
		}
		if (plus & Energy > 0 & EngineEnergy < EngineEnergyMax)
		{
			Energy--;
			EngineEnergy++;
		}
		EnergyChange();
	}
	public void OxygenClicked(bool plus)
	{
		if (!plus & Energy < EnergyMax & OxygenEnergy > 0)
		{
			Energy++;
			OxygenEnergy--;
		}
		if (plus & Energy > 0 & OxygenEnergy < OxygenEnergyMax)
		{
			Energy--;
			OxygenEnergy++;
		}
		EnergyChange();
	}
	public void MedbayClicked(bool plus)
	{
		if (!plus & Energy < EnergyMax & MedbayEnergy > 0)
		{
			Energy++;
			MedbayEnergy--;
		}
		if (plus & Energy > 0 & MedbayEnergy < MedbayEnergyMax)
		{
			Energy--;
			MedbayEnergy++;
		}
		EnergyChange();
	}
	public void CloakClicked(bool plus)
	{
		if (!plus & Energy < EnergyMax & CloakEnergy > 0)
		{
			Energy++;
			CloakEnergy--;
		}
		if (plus & Energy > 0 & CloakEnergy < CloakEnergyMax)
		{
			Energy--;
			CloakEnergy++;
		}
		EnergyChange();
	}
    public void ClickedWeapon1Power(bool plus)
    {
        if (!plus & Weapon1Powered)
        {
            WeaponEnergy -= weapons[Weapon1ID].Energy;
            Energy += weapons[Weapon1ID].Energy;
            Weapon1Powered = false;
        }
		if (plus & !Weapon1Powered)
        {
            if (Energy >= weapons[Weapon1ID].Energy & WeaponEnergyMax - WeaponEnergy >= weapons[Weapon1ID].Energy)
            {
                WeaponEnergy += weapons[Weapon1ID].Energy;
                Energy -= weapons[Weapon1ID].Energy;
                Weapon1Powered = true;
                StartCoroutine(Weapon1Charge());
            }
        }
        WeaponChange();
        WeaponEnergyChange();
    }
	public void ClickedWeapon2Power(bool plus)
	{
		if (!plus & Weapon2Powered)
		{
			WeaponEnergy -= weapons[Weapon2ID].Energy;
			Energy += weapons[Weapon2ID].Energy;
			Weapon2Powered = false;
		}
		if (plus & !Weapon2Powered)
		{
			if (Energy >= weapons[Weapon2ID].Energy & WeaponEnergyMax - WeaponEnergy >= weapons[Weapon2ID].Energy)
			{
				WeaponEnergy += weapons[Weapon2ID].Energy;
				Energy -= weapons[Weapon2ID].Energy;
				Weapon2Powered = true;
                StartCoroutine(Weapon2Charge());
            }
		}
		WeaponChange();
		WeaponEnergyChange();
	}
	public void ClickedWeapon3Power(bool plus)
	{
		if (!plus & Weapon3Powered)
		{
			WeaponEnergy -= weapons[Weapon3ID].Energy;
			Energy += weapons[Weapon3ID].Energy;
			Weapon3Powered = false;
		}
		if (plus & !Weapon3Powered)
		{
			if (Energy >= weapons[Weapon3ID].Energy & WeaponEnergyMax - WeaponEnergy >= weapons[Weapon3ID].Energy)
			{
				WeaponEnergy += weapons[Weapon3ID].Energy;
				Energy -= weapons[Weapon3ID].Energy;
				Weapon3Powered = true;
                StartCoroutine(Weapon3Charge());
            }
		}
		WeaponChange();
		WeaponEnergyChange();
	}
	public void ClickedWeapon4Power(bool plus)
	{
		if (!plus & Weapon4Powered)
		{
			WeaponEnergy -= weapons[Weapon4ID].Energy;
			Energy += weapons[Weapon4ID].Energy;
			Weapon4Powered = false;
		}
		if (plus & !Weapon4Powered)
		{
			if (Energy >= weapons[Weapon4ID].Energy & WeaponEnergyMax - WeaponEnergy >= weapons[Weapon4ID].Energy)
			{
				WeaponEnergy += weapons[Weapon4ID].Energy;
				Energy -= weapons[Weapon4ID].Energy;
				Weapon4Powered = true;
                StartCoroutine(Weapon4Charge());
            }
		}
		WeaponChange();
		WeaponEnergyChange();
	}

    //update UI

	void HullHpChange()
	{
		GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHpText").GetComponent<Text>().text = Convert.ToString(HullHp);
		switch (HullHp)
		{
		case 0:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = Nothing;
			break;
		case 1:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp1;
			break;
		case 2:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp2;
			break;
		case 3:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp3;
			break;
		case 4:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp4;
			break;
		case 5:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp5;
			break;
		case 6:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp6;
			break;
		case 7:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp7;
			break;
		case 8:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp8;
			break;
		case 9:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp9;
			break;
		case 10:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp10;
			break;
		case 11:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp11;
			break;
		case 12:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp12;
			break;
		case 13:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp13;
			break;
		case 14:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp14;
			break;
		case 15:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp15;
			break;
		case 16:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp16;
			break;
		case 17:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp17;
			break;
		case 18:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp18;
			break;
		case 19:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp19;
			break;
		case 20:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp20;
			break;
		case 21:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp21;
			break;
		case 22:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp22;
			break;
		case 23:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp23;
			break;
		case 24:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp24;
			break;
		case 25:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp25;
			break;
		case 26:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp26;
			break;
		case 27:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp27;
			break;
		case 28:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp28;
			break;
		case 29:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp29;
			break;
		case 30:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = HullHp30;
			break;
		default:
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("HullHp").GetComponent<Image>().sprite = MissingTexture;
			break;
		}
	}
	void ShieldChange()
	{
		for (int i = 0; i < 4; i++)
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("Shield" + Convert.ToString(i + 1)).GetComponent<Image>().sprite = Nothing;
		for (int i = 0; i < ShieldMax; i++)
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("Shield" + Convert.ToString(i + 1)).GetComponent<Image>().sprite = ShieldOff;
		for (int i = 0; i < Shield; i++)
			GameObject.Find("EnemyUI").transform.Find("Hull_Shield").transform.Find("Shield" + Convert.ToString(i + 1)).GetComponent<Image>().sprite = ShieldOn;
		GameObject.Find("EnemyShip").transform.Find("shield").GetComponent<SpriteRenderer>().color = new Color32((byte)255, (byte)255, (byte)255, (byte)(255 - 50 * (4 - Shield)));
		if (Shield == 0)
			GameObject.Find("EnemyShip").transform.Find("shield").GetComponent<SpriteRenderer>().color = new Color32((byte)255, (byte)255, (byte)255, (byte)0);
	}
    void EnergyChange()
    {
        ShieldEnergyChange();
        EngineEnergyChange();
        OxygenEnergyChange();
        MedbayEnergyChange();
        WeaponEnergyChange();
        CockpitEnergyChange();
        DoorEnergyChange();
        SensorEnergyChange();
        CloakEnergyChange();
    }
	void WeaponChange()
	{
        if (PlayerSensor >= 2)
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon1").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon1ID].Name + " " + Math.Round(Weapon1ChargingPercent / (float)weapons[Weapon1ID].ChargeRate * 10, 0) + "%"));
        else
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon1").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon1ID].Name));
        if (PlayerSensor >= 2)
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon2").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon2ID].Name + " " + Math.Round(Weapon2ChargingPercent / (float)weapons[Weapon2ID].ChargeRate * 10, 0) + "%"));
        else
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon2").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon2ID].Name));
        if (PlayerSensor >= 2)
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon3").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon3ID].Name + " " + Math.Round(Weapon3ChargingPercent / (float)weapons[Weapon3ID].ChargeRate * 10, 0) + "%"));
        else
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon3").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon3ID].Name));
        if (PlayerSensor >= 2)
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon4").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon4ID].Name + " " + Math.Round(Weapon4ChargingPercent / (float)weapons[Weapon4ID].ChargeRate * 10, 0) + "%"));
        else
            GameObject.Find("Ships").transform.Find("Enemy").transform.Find("EnemyUI").transform.Find("Weapon4").GetComponent<Text>().text = (Convert.ToString(weapons[Weapon4ID].Name));
        EnergyChange ();
	}
	void ShieldEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconShield").GetComponent<Enemy_Icon> ().Change (ShieldEnergyMax, ShieldEnergy, ShieldEnergyDamaged);
		ShieldMax = ShieldEnergyMax / 2;
        if (Shield + 1 > ShieldEnergy / 2)
            ShieldInterrupt = true;
        if (Shield > ShieldEnergy / 2)
            Shield = ShieldEnergy / 2;
        ShieldChange ();
	}
	void EngineEnergyChange()
	{
		Evade = 10 * (EngineEnergy * 0.25f + 0.75f);
		if (EngineEnergy == 0)
			Evade = 0;
		GameObject.Find ("EnemyUI").transform.Find ("IconEngine").GetComponent<Enemy_Icon> ().Change (EngineEnergyMax, EngineEnergy, EngineEnergyDamaged);
	}
	void OxygenEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconOxygen").GetComponent<Enemy_Icon> ().Change (OxygenEnergyMax, OxygenEnergy, OxygenEnergyDamaged);
	}
	void MedbayEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconMedbay").GetComponent<Enemy_Icon> ().Change (MedbayEnergyMax, MedbayEnergy, MedbayEnergyDamaged);
	}
	void WeaponEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconWeapon").GetComponent<Enemy_Icon> ().Change (WeaponEnergyMax, WeaponEnergy, WeaponEnergyDamaged);
	}
	void CockpitEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconCockpit").GetComponent<Enemy_Icon> ().Change (CockpitEnergyMax, CockpitEnergyMax, CockpitEnergyDamaged);
	}
	void DoorEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconDoor").GetComponent<Enemy_Icon> ().Change (DoorEnergyMax, DoorEnergyMax, DoorEnergyDamaged);
	}
	void SensorEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconSensor").GetComponent<Enemy_Icon> ().Change (SensorEnergyMax, SensorEnergyMax, SensorEnergyDamaged);
	}
	void CloakEnergyChange()
	{
		GameObject.Find ("EnemyUI").transform.Find ("IconCloak").GetComponent<Enemy_Icon> ().Change (CloakEnergyMax, CloakEnergy, CloakEnergyDamaged);
	}

	//Comms (between scripts)

	public void _SetRoomRole(int x, int y, string role)
	{
        ship [x, y].role = role;
	}
	public int _GetMedbayEnergy()
	{
		return(MedbayEnergy);
	}
	public int _GetShield()
	{
		return(Shield);
	}
	public float _GetEvade()
	{
		return(Evade);
	}
	public void _Damage(Vector2Int Destination, int SystemDamage, int HullDamage, int CrewDamage, bool Breach, bool Fire)
	{
        if (ship[Destination.x, Destination.y].crew != 0)
            transform.Find("crew" + ship[Destination.x, Destination.y].crew).GetComponent<Enemy_Crew>()._Damage(CrewDamage);
        HullHp -= HullDamage;
        GameObject.Find("Player").transform.Find("Ship").GetComponent<Ship>()._EnemyHp(HullHp);
        HullHpChange ();
		switch (ship[Destination.x,Destination.y].role)
		{
		case "Shield":
			ShieldRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (ShieldEnergyMax > 0)
				{
					if (ShieldEnergy == ShieldEnergyMax)
					{
						ShieldEnergy--;
						ShieldEnergyMax--;
						Energy++;
					}
					else
					{
						ShieldEnergyMax--;
					}
					ShieldEnergyDamaged++;
					ShieldEnergyChange ();
				}
			}
			break;
		case "Engine":
			EngineRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (EngineEnergyMax > 0)
				{
					if (EngineEnergy == EngineEnergyMax)
					{
						EngineEnergy--;
						EngineEnergyMax--;
						Energy++;
					}
					else
					{
						EngineEnergyMax--;
					}
					EngineEnergyDamaged++;
					EngineEnergyChange ();
				}
			}
			break;
		case "Oxygen":
			OxygenRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (OxygenEnergyMax > 0)
				{
					if (OxygenEnergy == OxygenEnergyMax)
					{
						OxygenEnergy--;
						OxygenEnergyMax--;
						Energy++;
					}
					else
					{
						OxygenEnergyMax--;
					}
					OxygenEnergyDamaged++;
					OxygenEnergyChange ();
				}
			}
			break;
		case "Medbay":
			MedbayRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (MedbayEnergyMax > 0)
				{
					if (MedbayEnergy == MedbayEnergyMax)
					{
						MedbayEnergy--;
						MedbayEnergyMax--;
						Energy++;
					}
					else
					{
						MedbayEnergyMax--;
					}
					MedbayEnergyDamaged++;
					MedbayEnergyChange ();
				}
			}
			break;
		case "Weapon":
			int temp;
			WeaponRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				temp = 0;
				if (WeaponEnergyMax > 0)
				{
					if (WeaponEnergy == WeaponEnergyMax)
					{
						WeaponEnergyMax--;
						if (Weapon1Powered)
							temp += weapons [Weapon1ID].Energy;
						if (Weapon2Powered)
							temp += weapons [Weapon2ID].Energy;
						if (Weapon3Powered)
							temp += weapons [Weapon3ID].Energy;
						if (Weapon4Powered)
							temp += weapons [Weapon4ID].Energy;
						if (temp > WeaponEnergyMax)
						{
							if (Weapon4Powered)
							{
								Energy += weapons [Weapon4ID].Energy;
								WeaponEnergy -= weapons [Weapon4ID].Energy;
								temp -= weapons [Weapon4ID].Energy;
								Weapon4Powered = false;
							}
						}
						if (temp > WeaponEnergyMax)
						{
							if (Weapon3Powered)
							{
								Energy += weapons [Weapon3ID].Energy;
								WeaponEnergy -= weapons [Weapon3ID].Energy;
								temp -= weapons [Weapon3ID].Energy;
								Weapon3Powered = false;
							}
						}
						if (temp > WeaponEnergyMax)
						{
							if (Weapon2Powered)
							{
								Energy += weapons [Weapon2ID].Energy;
								WeaponEnergy -= weapons [Weapon2ID].Energy;
								temp -= weapons [Weapon2ID].Energy;
								Weapon2Powered = false;
							}
						}
						if (temp > WeaponEnergyMax)
						{
							if (Weapon1Powered)
							{
								Energy += weapons [Weapon1ID].Energy;
								WeaponEnergy -= weapons [Weapon1ID].Energy;
								temp -= weapons [Weapon1ID].Energy;
								Weapon1Powered = false;
							}
						}
						WeaponChange ();
					}
					else
					{
						WeaponEnergyMax--;
					}
					WeaponEnergyDamaged++;
					WeaponEnergyChange ();
				}
			}
			break;
		case "Cockpit":
			CockpitRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (CockpitEnergyMax > 0)
				{
					CockpitEnergyMax--;
					CockpitEnergyDamaged++;
					CockpitEnergyChange ();
				}
			}
			break;
		case "Door":
			DoorRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (DoorEnergyMax > 0)
				{
					DoorEnergyMax--;
					DoorEnergyDamaged++;
					DoorEnergyChange ();
				}
			}
			break;
		case "Sensor":
			SensorRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (SensorEnergyMax > 0)
				{
					SensorEnergyMax--;
					SensorEnergyDamaged++;
					SensorEnergyChange ();
				}
			}
			break;
		case "Cloak":
			CloakRepairPercent = 0;
			for (int i = 0; i < SystemDamage; i++)
			{
				if (CloakEnergyMax > 0)
				{
					if (CloakEnergy == CloakEnergyMax)
					{
						CloakEnergy--;
						CloakEnergyMax--;
						Energy++;
					}
					else
					{
						CloakEnergyMax--;
					}
					CloakEnergyDamaged++;
					CloakEnergyChange ();
				}
			}
			break;
		}
	}
	public void _ShieldDamage(int ShieldDamage)
	{
		ShieldPercent = 0;
		Shield -= ShieldDamage;
		ShieldChange ();
	}

    //AI

    Vector2Int ShieldAI, EngineAI, OxygenAI, MedbayAI, WeaponAI, CockpitAI, DoorAI, SensorAI;
    IEnumerator InitializeAI()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        for (int i = w; i > 0; i--)
        {
            for (int j = h; j > 0; j--)
            {
                switch (ship[i, j].role)
                {
                    case "Shield":
                        ShieldAI.x = i;
                        ShieldAI.y = j;
                        break;
                    case "Engine":
                        EngineAI.x = i;
                        EngineAI.y = j;
                        break;
                    case "Oxygen":
                        OxygenAI.x = i;
                        OxygenAI.y = j;
                        break;
                    case "Medbay":
                        MedbayAI.x = i;
                        MedbayAI.y = j;
                        break;
                    case "Weapon":
                        WeaponAI.x = i;
                        WeaponAI.y = j;
                        break;
                    case "Cockpit":
                        CockpitAI.x = i;
                        CockpitAI.y = j;
                        break;
                    case "Door":
                        DoorAI.x = i;
                        DoorAI.y = j;
                        break;
                    case "Sensor":
                        SensorAI.x = i;
                        SensorAI.y = j;
                        break;
                }

            }
        }
    }
    IEnumerator AI()
    {
        while (true)
        {
            if (CockpitEnergyDamaged > 0 | MedbayEnergyDamaged == 0)
            {
                selected = 1;
                Navigate(CockpitAI.x, CockpitAI.y);
            }
            else
            {
                if (MedbayEnergyDamaged > 0)
                {
                    selected = 1;
                    Navigate(MedbayAI.x, MedbayAI.y);
                }
            }
            if (WeaponEnergyDamaged > 0 | DoorEnergyDamaged == 0)
            {
                selected = 2;
                Navigate(WeaponAI.x, WeaponAI.y);
            }
            else
            {
                if (DoorEnergyDamaged > 0)
                {
                    selected = 2;
                    Navigate(DoorAI.x, DoorAI.y);
                }
            }
            if (ShieldEnergyDamaged > 0 | OxygenEnergyDamaged == 0)
            {
                selected = 3;
                Navigate(ShieldAI.x, ShieldAI.y);
            }
            else
            {
                if (OxygenEnergyDamaged > 0)
                {
                    selected = 3;
                    Navigate(OxygenAI.x, OxygenAI.y);
                }
            }
            if (EngineEnergyDamaged > 0 | SensorEnergyDamaged == 0)
            {
                selected = 4;
                Navigate(EngineAI.x, EngineAI.y);
            }
            else
            {
                if (SensorEnergyDamaged > 0)
                {
                    selected = 4;
                    Navigate(SensorAI.x, SensorAI.y);
                }
            }
            if (ShieldEnergy % 2 != 0)
                ShieldClicked(false);
            if (OxygenEnergy == 0)
            {
                if (Energy == 0)
                    EngineClicked(false);
                if (Energy == 0)
                {
                    ShieldClicked(false);
                    ShieldClicked(false);
                }
                OxygenClicked(true);
            }
            while ((ShieldEnergyMax - ShieldEnergyDamaged) - ((ShieldEnergyMax - ShieldEnergyDamaged) % 2) > ShieldEnergy & Energy + EngineEnergy >= 2)
            {
                while (Energy < 2)
                {
                    EngineClicked(false);
                }
                ShieldClicked(true);
                ShieldClicked(true);
            }
            if (!Weapon1Powered & Energy + EngineEnergy >= weapons[Weapon1ID].Energy & Weapon1ID != 0 & WeaponEnergyMax - WeaponEnergy - WeaponEnergyDamaged >= weapons[Weapon1ID].Energy)
            {
                while (Energy < weapons[Weapon1ID].Energy)
                {
                    EngineClicked(false);
                }
                ClickedWeapon1Power(true);
            }
            if (!Weapon2Powered & Energy + EngineEnergy >= weapons[Weapon2ID].Energy & Weapon2ID != 0 & WeaponEnergyMax - WeaponEnergy - WeaponEnergyDamaged >= weapons[Weapon2ID].Energy)
            {
                while (Energy < weapons[Weapon2ID].Energy)
                {
                    EngineClicked(false);
                }
                ClickedWeapon2Power(true);
            }
            if (!Weapon3Powered & Energy + EngineEnergy >= weapons[Weapon3ID].Energy & Weapon3ID != 0 & WeaponEnergyMax - WeaponEnergy - WeaponEnergyDamaged >= weapons[Weapon3ID].Energy)
            {
                while (Energy < weapons[Weapon3ID].Energy)
                {
                    EngineClicked(false);
                }
                ClickedWeapon3Power(true);
            }
            if (!Weapon4Powered & Energy + EngineEnergy >= weapons[Weapon4ID].Energy & Weapon4ID != 0 & WeaponEnergyMax - WeaponEnergy - WeaponEnergyDamaged >= weapons[Weapon4ID].Energy)
            {
                while (Energy < weapons[Weapon4ID].Energy)
                {
                    EngineClicked(false);
                }
                ClickedWeapon4Power(true);
            }
            while (Energy > 0 & EngineEnergy + EngineEnergyDamaged < EngineEnergyMax)
            {
                EngineClicked(true);
            }
            yield return new WaitForSeconds(4);
        }
    }
}