using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";// Name of the item
	public Sprite icon = null;			// Item Icon
	public bool isDefaultItem = false;	//Is the item default to wear?
	
	public virtual void Use()
	{

		//Use the item
		//Something might happen

		Debug.Log("Using " + name);
	}
}
