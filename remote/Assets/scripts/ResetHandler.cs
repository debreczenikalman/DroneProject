using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHandler : MonoBehaviour
{

	// public float rightHandleDefaultPosY;
	public bool rightHandleIsDragging = false;
	public GameObject RightJoystickGameObj;
	public GameObject RightHandleGameObj;

	FixedJoystick fj;

	// Start is called before the first frame update
	void Start()
	{
		fj = RightJoystickGameObj.GetComponent<FixedJoystick>();
		// rightHandleDefaultPosY = -128;
		// RightHandleGameObj.transform.SetLocalPositionAndRotation(new Vector3(0, -127, 0), new Quaternion());
	}
	
	// Update is called once per frame
	void Update()
	{
		if(fj.isDragging)
		{
			// rightHandleDefaultPosY = RightHandleGameObj.transform.localPosition.y;
		} 
		else
		{
			RightHandleGameObj.transform.SetLocalPositionAndRotation(new Vector3(0, 0, 0),new Quaternion());
		}
	}
}
