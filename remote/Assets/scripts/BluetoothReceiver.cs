using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluetoothReceiver : MonoBehaviour
{
    public GameObject gyroBack;
    public GameObject gyroFront;




    // Update is called once per frame
    void FixedUpdate()
    {
        SetRotationOfGyro(gyroBack.transform.rotation.x, gyroBack.transform.rotation.y, gyroBack.transform.rotation.z+100);
    }

    void SetRotationOfGyro(float x, float y, float z)
	{
        gyroBack.transform.Rotate(x*Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
        gyroFront.transform.Rotate(x*Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);

        //gyro.transform.rotation.y = y;
        //gyro.transform.rotation.z = z;

	}


}
