using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletForce;
    public Vector3 origin;
    public Vector3 target;
    public float maxHeight = 10;
    public float t;
    public float gravity = 10;
    Rigidbody2D rb;
    Vector2 lookDir;
    float D;
    float V0x;
    float V0y;
    Animator animator;
    float T0;
    
    void Start()
    {
        maxHeight = 1;
        float heigth;
        if (t > 1)
            heigth = maxHeight + (1/t) * maxHeight;
        else
            heigth = 2 * maxHeight;
    
        D = 2 * Mathf.Sqrt(2 * heigth / gravity);
        V0x = (target.x - origin.x) / D;
        V0y = ((target.y - origin.y) / D) +  0.5f * gravity * D;
        // bulletForce = 20;
        rb = GetComponent<Rigidbody2D>();
        // lookDir.x = 0;
        // lookDir.y = 0;
        T0 = Time.time;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float T = Time.time - T0;
        if (T < D) {
        float x = origin.x + V0x * T;
        float y = origin.y + V0y * T - (0.5f * gravity * (T * T));
        
        transform.position = new Vector2(x, y);

        } else if (T > D) {
            animator.Play("explosion1");
            Destroy(gameObject, 0.24f);
        }

    }
}
