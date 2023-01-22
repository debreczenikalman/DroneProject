using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataProcess : MonoBehaviour
{
	public Transform left;
	public Transform right;
	public GameObject scriptGameObj;
	public GameObject toggle2;
	public GameObject deadZoneLabel;
	public GameObject btnDeadzoneUp;
	public GameObject btnDeadzoneDown;
	private float deadZoneTreshold = 30;
	public GameObject testImg;
	public GameObject maxValueField;
	public GameObject errorField;
	float rightYMax = 1023f;

	// Update is called once per frame
	void EditToggleText()
	{
		toggle2.GetComponent<Toggle>().GetComponentInChildren<Text>().text = "Aux1 = " + ((toggle2.GetComponent<Toggle>().isOn) ? "1" : "0");
	}
	void IncreaseDeadZone()
	{
		deadZoneTreshold += 5;
		ChangeDeadZoneLabel();
	}
	void DecreaseDeadZone()
	{
		if (deadZoneTreshold > 0)
		{
			deadZoneTreshold -= 5;
			ChangeDeadZoneLabel();
		}
	}
	void ChangeDeadZoneLabel()
	{
		deadZoneLabel.GetComponent<Text>().text = deadZoneTreshold.ToString();
	}

	void MaxValueChange()
	{
		// Debug.Log("MaxValueChange()");
		if (maxValueField.GetComponent<InputField>().text == "")
		{
			rightYMax = 1023f;
			return;
		}
		if (!float.TryParse(maxValueField.GetComponent<InputField>().text, out rightYMax))
		{
			rightYMax = 1023f;
			errorField.GetComponent<Text>().enabled = true;
		}
		else
		{
			if (rightYMax > 1023f)
			{
				rightYMax = 1023f;
				errorField.GetComponent<Text>().enabled = true;
			}
			else
			{
				errorField.GetComponent<Text>().enabled = false;

			}

		}

	}

	private void Start()
	{
		toggle2.GetComponent<Toggle>().onValueChanged.AddListener(delegate { EditToggleText(); });
		btnDeadzoneUp.GetComponent<Button>().onClick.AddListener(delegate { IncreaseDeadZone(); });
		btnDeadzoneDown.GetComponent<Button>().onClick.AddListener(delegate { DecreaseDeadZone(); });
		maxValueField.GetComponent<InputField>().onValueChanged.AddListener(delegate { MaxValueChange(); });
		ChangeDeadZoneLabel();
	}

	public int[] GetPositions(float Lowest = 0f, float Highest = 1023f)
	{
		// Debug.Log((toggle2.GetComponent<Toggle>().isOn));
		int aux1 = (toggle2.GetComponent<Toggle>().isOn) ? 1 : 0;
		float leftX;
		float leftY;
		float rightX;
		float rightY;


		leftX = left.localPosition.x;
		//leftX /= 128;
		//leftX = Mathf.Pow(leftX, 5) * 128;

		leftY = left.localPosition.y;
		//leftY /= 128;
		//leftY = Mathf.Pow(leftY, 5) * 128;

		rightX = right.localPosition.x;
		if (Mathf.Abs(rightX) < deadZoneTreshold)
		{
			rightX = 0;
		}
		else
		{
			if (rightX > 0)
			{
				rightX -= deadZoneTreshold;
			}
			else
			{
				rightX += deadZoneTreshold;
			}
			rightX /= 128 - deadZoneTreshold; // TODO: fix
			rightX *= 128;
			// Debug.Log(rightX);
			//rightX = Mathf.Pow(rightX, 5) * (128);
		}

		// Debug.Log(rightYMax);
		rightY = right.localPosition.y;
		//rightY /= 128;
		//rightY = Mathf.Pow(rightY, 5) * 128;



		leftX = (leftX + 128) / 256 * (Highest - Lowest) + Lowest;
		leftY = (leftY + 128) / 256 * (Highest - Lowest) + Lowest;
		rightX = (rightX + 128) / 256 * (Highest - Lowest) + Lowest;
		rightY = (rightY + 128) / 256 * (rightYMax - Lowest) + Lowest;

		// toggle2.ToString();

		// macerálva sorrendhez 
		return new int[] { (int)System.Math.Round(rightY), (int)System.Math.Round(rightX), (int)System.Math.Round(leftY), (int)System.Math.Round(leftX), aux1 };

	}

	void Update()
	{
		int[] arr = GetPositions();
		scriptGameObj.GetComponent<BluetoothSender>().DataToSend = arr[0] + "," + arr[1] + "," + arr[2] + "," + arr[3] + "," + arr[4] + ",0" + '\n';
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