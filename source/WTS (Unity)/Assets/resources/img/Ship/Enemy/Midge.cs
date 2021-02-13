using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midge : MonoBehaviour
{
	void Start ()
	{
		int EnergyMax = 100;
		int ShieldEnergyMax = 8;
		int EngineEnergyMax = 2;
		int OxygenEnergyMax = 1;
		int MedbayEnergyMax = 1;
		int WeaponEnergyMax = 4;
		int CockpitEnergyMax = 1;
		int DoorEnergyMax = 1;
		int SensorEnergyMax = 1;
		int CloakEnergyMax = 0;
		int Weapon1ID = 2;
		int Weapon2ID = 2;
		int Weapon3ID = 2;
		int Weapon4ID = 2;
		int Ammo = 3;
		int HullHp = 10;
        string Name = "Midge";

		gameObject.GetComponent<Enemy_Ship>().InitializeStats(EnergyMax, ShieldEnergyMax, EngineEnergyMax, OxygenEnergyMax, MedbayEnergyMax, WeaponEnergyMax, CloakEnergyMax, CockpitEnergyMax, DoorEnergyMax, SensorEnergyMax, Weapon1ID, Weapon2ID, Weapon3ID, Weapon4ID, Ammo, HullHp, Name);
		//ShipWidth+3=18, ShipHeight+3=9
		gameObject.GetComponent<Enemy_Ship> ().Initialize (7, 10);
		//x, y, orientation
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 2, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 2, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 2, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 2, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 2, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 2, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 3, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 3, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 3, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 3, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 3, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 3, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 3, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 3, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 3, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 3, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 4, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 4, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 4, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 4, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 4, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 4, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 4, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 4, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 4, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 4, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 5, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 5, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 5, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 5, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 6, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 6, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 6, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 6, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 7, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 7, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 7, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 7, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 7, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 7, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 7, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 7, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 7, "top");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 7, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 8, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 8, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (2, 8, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 8, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (3, 8, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 8, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (4, 8, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 8, "left");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 8, "bottom");
		gameObject.GetComponent<Enemy_Ship> ().InitializeWalls (5, 8, "right");
		gameObject.GetComponent<Enemy_Ship> ().InitializeDoors ();
	}
}
