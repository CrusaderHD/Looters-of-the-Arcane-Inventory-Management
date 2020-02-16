using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	//Script is attached to the Game Manager.

	#region Singleton
	public static EquipmentManager instance;

	void Awake()
	{
		instance = this;
	}
	#endregion



	public GameObject target; //Target of which inventory will be set to. In this instance our target is player.

	Equipment[] currentEquipment;  //Gathering an array of current equipment
	GameObject[] deployableObjects; //Gathering game objects as a deployable object. i.e: RC Car, or another item the player will "Deploy" in the world. See enum on Equipment script.
	Inventory inventory;  //Accessing the Inventory Script.

	void Start()
	{
		int numInvenSlots = System.Enum.GetNames (typeof(EquipmentSlot)).Length; 
		currentEquipment = new Equipment[numInvenSlots];
		inventory = Inventory.instance;
	}

	public void Equip(Equipment newItem)
	{
		int slotIndex = (int)newItem.equipSlot;

		Equipment oldItem = null;

		if (currentEquipment [slotIndex] != null) 
		{
			oldItem = currentEquipment [slotIndex];
			inventory.Add (oldItem);
		}

		currentEquipment [slotIndex] = newItem;
	}
}
