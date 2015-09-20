using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour 
{

	public Transform target;
	public static float distance = 5.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	public float yMargin;

	public bool NeedSmooth ;
	public float smooth = 0.0f;
	
	public bool LimitX = false;
	public static float x = 0.0f;
	public bool LimitY = false;
	public static float y = 0.0f;

	public float OCCShooth;
	public Vector2 ShowXY;
	
	void Start () 
	{

		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	void LateUpdate () 
	{
		ShowXY = new Vector2(x,y);
		if (target) 
		{
			if (!LimitX)
			{
				x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
			}
			if (!LimitY)
			{
				y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
				y = ClampAngle(y, yMinLimit, yMaxLimit);
			}	

			if (x > 360)
			{
				x -= 360;
			}
			else if (x < 0)
			{
				x += 360;
			}
			
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			
			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime*60, distanceMin, distanceMax);

			Vector3 negDistance;
			Vector3 position = Vector3.zero;

			DrawCollderLine();

			negDistance = new Vector3(0.0f, 0.0f, -distance);
			if (NeedSmooth)
			{
				//position = Vector3.Lerp(transform.position,rotation * negDistance + target.position, Time.deltaTime * smooth);
				position.x = (rotation * negDistance).x + target.position.x;
				position.z = (rotation * negDistance).z + target.position.z;

				if (CheckYMargin())
					position.y = Mathf.Lerp(transform.position.y , rotation.y * negDistance.y + target.position.y , Time.deltaTime * smooth);
				else
					//position.y = (rotation * negDistance).y + target.position.y;
					position.y = transform.position.y;
			}
			else
			{
				//position = rotation * negDistance + target.position;
				position.x = (rotation * negDistance).x + target.position.x;
				position.y = (rotation * negDistance).y + target.position.y;
				position.z = (rotation * negDistance).z + target.position.z;
			}
			transform.rotation = rotation;
			transform.position = position;
			//transform.LookAt(testLock.position);
		}
	}
	
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
	}

	private Vector3 DrawCollderLine()
	{
		/*Debug.DrawLine(transform.position , transform.position + transform.forward*0.5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.forward*-0.5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.right*0.5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.right*-0.5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.up*0.5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.up*-0.5f , Color.red);*/

		RaycastHit hit;

		if (Physics.Linecast(transform.position , transform.position + transform.forward*-0.5f , out hit) && CheckHitTag(hit.collider.tag))
			distance = Vector3.Distance (target.position,hit.point)-OCCShooth;
		if (Physics.Linecast(transform.position , transform.position + transform.right*0.5f , out hit) && CheckHitTag(hit.collider.tag))
			distance = Vector3.Distance (target.position,hit.point)-OCCShooth;
		if (Physics.Linecast(transform.position , transform.position + transform.right*-0.5f , out hit) && CheckHitTag(hit.collider.tag))
			distance = Vector3.Distance (target.position,hit.point)-OCCShooth;
		if (Physics.Linecast(transform.position , transform.position + transform.up*0.5f , out hit) && CheckHitTag(hit.collider.tag))
			distance = Vector3.Distance (target.position,hit.point)-OCCShooth;
		if (Physics.Linecast(transform.position , transform.position + transform.up*-0.2f , out hit) && CheckHitTag(hit.collider.tag))
			distance = Vector3.Distance (target.position,hit.point)-OCCShooth;
		if (Physics.Linecast (target.position , transform.position , out hit) && CheckHitTag(hit.collider.tag))
			distance = Vector3.Distance (target.position,hit.point)-OCCShooth;

		if (distance < distanceMin)
		{
			distance = distanceMin;
		}
		else if (distance > distanceMax)
		{
			distance = distanceMax;
		}

		return hit.point;
	}
	private bool CheckHitTag(string tag)
	{
		if (tag == "Player" | tag == "PlayerObject"  | tag == "Enemy_Boss"  | tag == "Enemy"  | tag == "EnemyDead" | tag == "Monster" | tag == "Sward" )
		{
			return false;
		}
		else
		{
			return true;
		}
	}
}
