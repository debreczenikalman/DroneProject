using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcess : MonoBehaviour
{
	public Transform left;
	public Transform right;
	public GameObject scriptGameObj;

	// Update is called once per frame
	public int[] GetPositions(float Lowest = 1000f, float Highest = 2000f)
	{
		float leftX;
		float leftY;
		float rightX;
		float rightY;
		

		leftX = left.localPosition.x;
		leftY = left.localPosition.y;
		rightX = right.localPosition.x;
		rightY = right.localPosition.y;

		leftX = (leftX + 128) / 256 * (Highest - Lowest) + Lowest;
		leftY = (leftY + 128) / 256 * (Highest - Lowest) + Lowest;
		rightX = (rightX + 128) / 256 * (Highest - Lowest) + Lowest;
		rightY = (rightY + 128) / 256 * (Highest - Lowest) + Lowest;
		// Debug.Log(leftX);

		//macerálva sorrendhez
		return new int[]{(int)System.Math.Round(rightY), (int)System.Math.Round(rightX), (int)System.Math.Round(leftY), (int)System.Math.Round(leftX)};

	}

	void Update(){
		int[] arr = GetPositions();
		
		scriptGameObj.GetComponent<BluetoothSender>().DataToSend = arr[0] + "," + arr[1] + "," + arr[2] + "," + arr[3];
	}

}
	/* ,
	HC12_rcData[THROTTLE] = map(throttle, 0, 1023, 1000, 2000);
    HC12_rcData[YAW] = map(yaw, 0, 1023, 1000, 2000);
    HC12_rcData[PITCH] = map(pitch, 0, 1023, 1000, 2000);
    HC12_rcData[ROLL] = map(roll, 0, 1023, 1000, 2000);
    HC12_rcData[AUX1] = map(aux1, 0, 1, 2000, 1000);
    HC12_rcData[AUX2] = 1000;
	*/