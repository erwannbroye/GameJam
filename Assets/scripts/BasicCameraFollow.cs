using UnityEngine;
using System.Collections;

public class BasicCameraFollow : MonoBehaviour 
{

	public Transform followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
	
	void Start()
	{

	}

	void Update () 
	{
		if(followTarget != null)
		{
			targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
		}
		// Vector2 worldTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Debug.DrawLine(new Vector2(worldTouch.x,worldTouch.y), new Vector2(0, 0), Color.red);
		// RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
         
        // if(hit != null && hit.collider != null){
            //  Debug.Log(hit.point);
        // }
	}
}

