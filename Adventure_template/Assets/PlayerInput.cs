using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputBehaviour
{	

	void Update ()
    {
        ActionA = Input.GetButtonDown("Action");
        ActionB = Input.GetButtonDown("UseItem");
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        CheckForEvents();
	}

}
