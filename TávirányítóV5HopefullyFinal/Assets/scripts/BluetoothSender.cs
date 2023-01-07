/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluetoothSender : MonoBehaviour
{
	public GameObject scriptGameObj;

	// Start is called before the first frame update
	void Start()
	{
		Connect();
	}
	void Connect()
	{

	}
	// Update is called once per frame
	void Update()
	{
		float[] arr = scriptGameObj.GetComponent<DataProcess>().GetPositions();
		Debug.Log(arr[0] + " " + arr[1] + " " + arr[2] + " " + arr[3]);
	}
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluetoothSender : MonoBehaviour
{

	//public Text deviceName;
	int millisecondsSinceLastSend;
	string dataToSend;
	public string DataToSend
	{
		set
		{
			dataToSend = value;
		}

	}
	public static string dataRecived = "";

	// Start is called before the first frame update
	void Start()
	{
		millisecondsSinceLastSend = 0;
		BluetoothService.CreateBluetoothObject();
		BluetoothService.StartBluetoothConnection("HC-06");
	}

	// Update is called once per frame
	void Update()
	{
		millisecondsSinceLastSend += (int)System.Math.Round(Time.deltaTime * 1000);
		SendData();
	}

	void SendData()
	{
		if (millisecondsSinceLastSend >= 100)
		{

			if ((dataToSend.ToString() != "" || dataToSend.ToString() != null))
			{
				BluetoothService.WritetoBluetooth(dataToSend);
			}
			// Debug.Log(dataToSend);
			millisecondsSinceLastSend = 0;
		}
	}
}