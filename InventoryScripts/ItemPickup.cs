using UnityEngine;


//Deriving the interactable script for our Item Pickup. This is the script that will need to go on in-game items that will be picked up by player in-game.
public class ItemPickup : Interactable {

	public Item item;


	public override void Interact()
	{
		base.Interact (); 
		Pickup ();
	}

	void Pickup()
	{
		
		//Debug.Log ("Picking up " + item.name);

		//Add item to inventory
		bool wasPickedUp = Inventory.instance.Add(item);

		//Remove item from Game
		if (wasPickedUp)
		{
			Destroy(gameObject);
		}

	}

}
