using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public GameObject[] inventory = new GameObject[10];

	public void AddItem(GameObject item)
	{
		bool itemAdded = false;

		//find the first open slot in the inventory
		for(int i = 0; i < inventory.Length; i++)
		{
			if (inventory[i] == null)
			{
				inventory[i] = item;
				itemAdded = true;
				item.SendMessage("DoInteraction");
				break;
			}
		}
		//inventory full
		if (!itemAdded)
		{

		}
	}

	public bool FindItem(GameObject item)
	{
		for(int i = 0; i < inventory.Length; i++)
		{
			if (inventory[i] == item)
			{
				//we found the item
				Debug.Log(inventory[i]);
				Debug.Log(item+"item");
				return true;
			}
		}
		//Item not found
		return false;
	}
    
}
