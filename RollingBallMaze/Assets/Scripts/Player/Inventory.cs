using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
	public GameObject[] inventory = new GameObject[3];
	public Button[] inventoryButtons = new Button[3];
	public void AddItem(GameObject item)
	{
		bool itemAdded = false;

		//find the first open slot in the inventory
		for(int i = 0; i < inventory.Length; i++)
		{
			if (inventory[i] == null)
			{
				inventory[i] = item;
				inventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
				itemAdded = true;
				item.SendMessage("DoInteraction");
				break;
			}
		}
		//inventory full
		if (!itemAdded)
		{
			itemAdded = false;
		}
	}

	public bool FindItem(GameObject item)
	{
		for(int i = 0; i < inventory.Length; i++)
		{
			if (inventory[i] == item)
			{
				//we found the item
				return true;
			}
		}
		//Item not found
		return false;
	}

	public void removeItem(GameObject item)
	{
		for (int i = 0; i < inventory.Length; i++)
		{
			if (inventory[i] == item)
			{
				//we found an item of the type we were looking for
				inventory[i] = null;
				inventoryButtons[i].image.overrideSprite = null;
				break;
			}
		}
	}

}
