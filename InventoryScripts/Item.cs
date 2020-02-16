using UnityEngine;
using UnityEngine.UI;

//Creating a sub-File when creating a new object in Project view. Prompts selection to be able to create an Item. 

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] 
public class Item : ScriptableObject {
	
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;

	public GameObject deployable;

	public Vector3 spawnOffset;


	Item item;


	public virtual void Use ()
	{
		
		//Use Item
		//Debug.Log("Using " + name);
		GameObject newItem = Instantiate (deployable, GameManager.instance.rcTransform.position + GameManager.instance.rcTransform.TransformDirection(spawnOffset), GameManager.instance.rcTransform.rotation) as GameObject;

		//Find Game Manager and access the RC Components
		GameObject.Find("GameManager").GetComponent<Remote>().rcCamera = newItem.GetComponent<TestWheels>().rcCamera;
	}

	public void RemoveFromInventory()
	{
		Inventory.instance.Remove (this);	
	}

}
