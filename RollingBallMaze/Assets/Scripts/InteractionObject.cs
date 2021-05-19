using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
	public bool inventory; //if true this object can be stored in inventory
	public bool openable; //if true this object can be opened
	public bool locked; //if true this object is locked
	public GameObject itemNeeded; //item neededin order to interact
	public Animator anim;
	
	public void DoInteraction()
	{
		//Pick up and put in inventory
		gameObject.SetActive(false);
	}

	public void open()
	{
		anim.SetBool("IsOpen", true);
	}
}
