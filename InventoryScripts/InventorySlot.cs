using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public Image icon;  
	Item item;
	public Transform itemSpawn;

	public KeyCode key; //Giving Access to change the desired key to press for corresponding inventory slot.

	//When a new item is added, it will pull the image details from the scriptable object and place image icon in inventory menu
	public void AddItem(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
	}

	//When an item is removed, it will trmove the image details from the scriptable object and remove image icon in inventory menu
	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
	}

	//Utilizing "Use" from Item script
	public void UseItem()
	{
		if (item != null)
		{
			item.Use ();
		}     
    }

	//Checking for player key pressed to use items in the inventory if inventory menu is active.
	public void Update()
	{
		if (Input.GetKeyDown (key))
		{
			if (item != null) 
			{
				item.Use ();
				//ClearSlot ();
				item.RemoveFromInventory ();
			}
		}
	}
}
