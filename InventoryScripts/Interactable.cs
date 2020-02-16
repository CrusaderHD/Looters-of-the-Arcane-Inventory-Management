using UnityEngine;
using UnityEngine.UI;


//The Script ItemPickup will derive from this script. If you have an object you want the player to interact with or pick up
//---->Be sure to palce the ItemPickup script on that item<-------
//NOT THIS ONE


public class Interactable : MonoBehaviour {

	public float pickupRadius = 2; //Setting a Radius of how far the player can be in order to pickup an item.

	public bool hasInteracted = false;  //Bool being set if player has or has not interacted with an object. 

	public Transform interactionTransform;
	public Transform player;


	//Creaing a virtual void called "Interact" that can be overridden in other scripts if need be. -> Currently being over ridden by ItemPickup Script.
	public virtual void Interact()
	{
		//Debug.Log (player.name + " Interacted with " + transform.name);
	}

	void Update()
	{
		if (!hasInteracted) 
		{
			if (player == null)
			{
				player = GameObject.FindGameObjectWithTag ("Player").transform;
			}
			float distance = Vector3.Distance (player.position, interactionTransform.position);
			if (distance <= pickupRadius) 
			{
				Interact ();
				hasInteracted = true;
			}
		}

	}

	//Drawing a Gizmo around game object/item. Gizmo will show in the scene view. 
	void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.green; //Setting gizmo around object to display as green.
		Gizmos.DrawWireSphere (interactionTransform.position, pickupRadius);
	}

}
