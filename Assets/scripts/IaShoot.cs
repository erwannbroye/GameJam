using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaShoot : MonoBehaviour
{
    public float reloadTime;
    public int bulletModel = 0;
    public GameObject [] bulletPrefab;
    public float rayon;
    Vector3 mousePos2;
    float T0;
    Vector2 playePos;
    float delta;
    float cPrime;
    Vector2 deltaV ;
    float t ;
    bool canFire = false;
    public AudioClip [] efxClips;

    void Start()
    {
        // mousePos2 = new Vector3(0, 0, 0);
        rayon = GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        float T = Time.time - T0;
            if (T > reloadTime && canFire) {
                T0 = Time.time;
                int tmp = Mathf.RoundToInt(Random.Range(0, 1));
                GetComponent<AudioSource>().PlayOneShot(efxClips[tmp], 1f);
                Shoot(0);
            }
        designPos();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            T0 = Time.time;
            canFire = true;
        }
    }

    private void OntriggerExit(Collider2D other) {
        if (other.tag == "Player") {
            T0 = Time.time;
            canFire = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {

        if (other.tag == "Player") {
            playePos = transform.position;
            mousePos2 = other.transform.position;
        }
        // designPos();
    }

    void designPos() 
    {
        cPrime = 2*rayon;
        delta = rayon * 0.86602f;
        Vector2 Ca = playePos + deltaV;
        Vector2 Cb = playePos - deltaV;
        float x0 = (Ca.x + Cb.x) / 2;
        float y0 = (Ca.y + Cb.y) / 2;
        float p1 = (cPrime);
        float p2 = (((mousePos2.x - x0) * (mousePos2.x - x0)) + 2 *((mousePos2.y - y0) * (mousePos2.y - y0)));

        t = rayon * Mathf.Sqrt(p1 / p2);
    }

    void Shoot(int i) {
        GameObject bullet = Instantiate(bulletPrefab[bulletModel - 1], transform.position, transform.rotation);
        bullet.GetComponent<bullet>().target = mousePos2 + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0);        
        bullet.GetComponent<bullet>().origin = transform.position + new Vector3(0.4f * i, 0, 0);
        bullet.GetComponent<bullet>().t = t;
    }
    
}
