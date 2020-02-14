using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform cursorPos;
    public GameObject bulletPrefab;
    public Camera cam;
    public float rayon;
    Vector2 mousePos2;
    Vector2 playePos;
    public float delta;
    public float cPrime;
    public Vector2 deltaV ;
    float t ;
    float T0;
    public AudioClip [] efxClips;


    public Level level;

    bool canFire;


    public float bulletForce;

    private void Start() {
        deltaV = new Vector2(delta, 0);
        level = GetComponent<Level>();
        T0 = Time.time;
        canFire = true;

    }
    void Update()
    {
        T0 += Time.deltaTime;
        rayon = level.range;
        playePos = transform.position;
        mousePos2 = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonUp("Fire1") && canFire == true) {
            for (int i = level.bulletNumber - 1; i >= 0; i --) {
                Shoot(i);
                if (level.canonLevel == 1) {
                    int tmp = Mathf.RoundToInt(Random.Range(0, 1));
                    GetComponent<AudioSource>().PlayOneShot(efxClips[tmp], 1f);
                }
                if (level.canonLevel == 2) {
                    int tmp = Mathf.RoundToInt(Random.Range(2, 3));
                     GetComponent<AudioSource>().PlayOneShot(efxClips[tmp], 1.0f);
                }
            }
            canFire = false;
            Debug.Log("BITE");
            T0 = 0;
        } else if (Input.GetButtonUp("Fire1") && canFire == false) {
            int tmp = Mathf.RoundToInt(Random.Range(4, 5));
            GetComponent<AudioSource>().PlayOneShot(efxClips[tmp], 1.0f);
        }
        // Debug.Log(T0);
        // Debug.Log(canFire);
        // Debug.Log(level.reloadTime);
        if (T0 > level.reloadTime && canFire == false)
            canFire = true;
        designPos();
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
        if (t > 1) {
            cursorPos.position = mousePos2;
        } else {
            cursorPos.position = new Vector2(x0 + t * (mousePos2.x - x0), y0 + t * (mousePos2.y - y0));
        }
    }

    void Shoot(int i) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<bullet>().target = cursorPos.position + new Vector3(0.4f * i, 0, 0);
        bullet.GetComponent<bullet>().origin = transform.position + new Vector3(0.4f * i, 0, 0);
        bullet.GetComponent<bullet>().t = t;
    }
}
