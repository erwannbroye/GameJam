using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public float bulletForce;
    public Vector3 targetPos;
    public Transform target;
    Rigidbody2D rb;
    Vector2 lookDir;
    
    void Start()
    {
        bulletForce = 20;
        rb = GetComponent<Rigidbody2D>();
        lookDir.x = 0;
        lookDir.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        Debug.Log(targetPos);
        if ((transform.position.x > targetPos.x - 0.1 && transform.position.x  < targetPos.x + 0.1) && (transform.position.y > targetPos.y - 0.1 && transform.position.y  < targetPos.y + 0.1)) {
            rb.velocity = lookDir;
            Debug.Log("STOP");
            Destroy(gameObject);
        }
    }
}
