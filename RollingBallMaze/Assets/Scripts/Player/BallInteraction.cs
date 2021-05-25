using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
	public GameObject currentKey = null;
	public InteractionObject currentInterKeyscript = null;
	public Inventory inventory;
	public GameObject instruction;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && currentKey)
		{
			//check to see if this object can be opened
			if (currentInterKeyscript.openable)
			{
				//check to see if this object is locked
				if (currentInterKeyscript.locked)
				{
					Debug.Log("item");
					//check to see if we have the object need to unclock
					//search our inventory for the item need -if found unlockobject
					if (inventory.FindItem(currentInterKeyscript.itemNeeded))
					{
						//we found the item needed
						Debug.Log("1");
						currentInterKeyscript.locked = false;
					}
				}
				else
				{
					StartCoroutine(Open());
					inventory.removeItem(currentInterKeyscript.itemNeeded);
				}
			}
		}

	}

	private IEnumerator Open()
	{
		yield return new WaitForSeconds(.1f);
		currentInterKeyscript.open();
	}
	private IEnumerator Intruction()
	{
		instruction.SetActive(true);
		yield return new WaitForSeconds(2f);
		instruction.SetActive(false);
	}
	public void PickUp()
	{
		if (currentKey)
		{
			//check inventory
			if (currentInterKeyscript.inventory)
			{
				inventory.AddItem(currentKey);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Key"))
		{
			StartCoroutine(Intruction());
			currentKey = collision.gameObject;
			currentInterKeyscript = currentKey.GetComponent<InteractionObject>();
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Key"))
		{
			if (collision.gameObject == currentKey)
			{
				currentKey = null;
			}
		}
	}
}
