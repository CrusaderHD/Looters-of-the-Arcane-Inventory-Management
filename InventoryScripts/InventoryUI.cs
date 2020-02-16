using UnityEngine;

public class InventoryUI : MonoBehaviour {


	Inventory inventory;

	public GameObject inventoryUI;

	public Transform itemsParent;

	public bool isInventoryOpen = false;
	public GameObject player;


	InventorySlot[] slots;

	// Use this for initialization
	void Start () {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Inventory"))
		{	
			PlayerController script = player.GetComponent<PlayerController>();
			if (isInventoryOpen) 
			{
				isInventoryOpen = false;
				script.enabled = true;
			}
			else
			{
				isInventoryOpen = true;
				script.enabled = false;
			}

			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
			
	}

	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots [i].AddItem (inventory.items [i]);
			} 
			else
			{
				slots [i].ClearSlot ();
			}
		}

	}

}
