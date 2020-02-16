using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	//If changed from 4 slots, other slots in the Inventory UI will need to be created and added.
	public int inventorySpace = 4;  //Current number of inventory slots available. 

	//Creating a singleton to test and make sure only one variance of Inventory is in the scene at any point in time.
	#region Singleton
	public static Inventory instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning ("More than one instance of Inventory found.");
			return;
		}
		instance = this;
	}
	#endregion


	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public List<Item> items = new List<Item>();

	public bool Add(Item item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= inventorySpace)
			{
				Debug.Log ("Not enough space in Inventory!!");
				return false;
			}

			items.Add (item);

			if (onItemChangedCallback != null)
			{
				onItemChangedCallback.Invoke ();
			}


		}
		return true;
	}

	public void Remove(Item item)
	{
		items.Remove (item);
		if (onItemChangedCallback != null)
		{
			onItemChangedCallback.Invoke ();
		}
	}


}
