using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletDamge = 10f;
    public float additionalDamage = 20f;
    public int bulletLevel = 0;
    public Vector3 origin;
    public Vector3 target;
    public float maxHeight = 10;
    public float t = 0;
    public float gravity = 10;
    Vector2 lookDir;
    float D;
    float V0x;
    float V0y;
    Animator animator;
    float T0;
    public bool isMoving;
    public bool typeBullet;
    public float explosionRadius = 0.5f;
    public AudioClip [] efxClips;

    
    public void init() 
    {
        maxHeight = 1;
        isMoving = true;
        float heigth;
        if (t > 1)
            heigth = maxHeight + (1/t) * maxHeight;
        else
            heigth = 2 * maxHeight;
    
        D = 2 * Mathf.Sqrt(2 * heigth / gravity);
        V0x = (target.x - origin.x) / D;
        V0y = ((target.y - origin.y) / D) +  0.5f * gravity * D;
        T0 = Time.time;
        if (bulletLevel >= 1) {
            explosionRadius *= 3;
            bulletDamge *= 2;
        }
    }
    void Start()
    {
        init();
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

        } else if (T > D && isMoving == true) {
            if (animator) {
                animator.Play("explosion1");
                int tmp = Mathf.RoundToInt(Random.Range(0, 1));
                if (GetComponent<AudioSource>())
                    GetComponent<AudioSource>().PlayOneShot(efxClips[tmp], 1.0f);
            }
            Destroy(gameObject, 0.24f);
            creatDamageZone(transform.position, explosionRadius);
            isMoving = false;
        }
    }

    void creatDamageZone(Vector2 pos, float rad) 
    {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(pos,rad);
            int i = 0;
            while (i < hitColliders.Length)
            {
                Debug.Log(hitColliders[i].tag);
                if (hitColliders[i].gameObject.GetComponent<HitCannon>() && !hitColliders[i].isTrigger) {
                    hitColliders[i].gameObject.GetComponent<HitCannon>().TakeDamages(bulletDamge);
                    if (bulletLevel >= 2 && typeBullet == true)
                        hitColliders[i].gameObject.GetComponent<HitCannon>().TakeDamagesOvertime(3f,additionalDamage);
                }
                if (hitColliders[i].gameObject.GetComponentInParent<IsometricPlayerMovementController>()) {
                    hitColliders[i].gameObject.GetComponentInParent<IsometricPlayerMovementController>().TakeDamages(bulletDamge);
                }
                i++; 
            }
    }
}
