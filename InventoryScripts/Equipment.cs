using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipSlot;

	//Overriding the original function Use. This will remove an item from a players inventory.
	public override void Use()
	{
		base.Use ();
		//Equip or Use Item
		EquipmentManager.instance.Equip(this);
		//Remove Item from Inventory
		RemoveFromInventory();
	}

}
	
public enum EquipmentSlot{Head, Chest, Legs, Feet, Shield, Weapon, Deployable}
