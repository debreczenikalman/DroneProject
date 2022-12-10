using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHandler : MonoBehaviour
{

    public float rightHandleDefaultPosX = 0;
    public bool rightHandleIsDragging = false;
    public GameObject RightJoystickGameObj;
    public GameObject RightHandleGameObj;

    FixedJoystick fj;

    // Start is called before the first frame update
    void Start()
    {
        fj = RightJoystickGameObj.GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fj.isDragging){
            rightHandleDefaultPosX = RightHandleGameObj.transform.localPosition.x;
        } else {
            RightHandleGameObj.transform.SetPositionAndRotation(
                new Vector3(rightHandleDefaultPosX, 0, 0),new Quaternion()
            );
        }
    }
}
