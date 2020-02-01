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
    Vector3 mousePos;
    Vector2 mousePos2;
    Vector2 playePos;
    public float delta;
    public float cPrime;
    public Vector2 deltaV ;

    public float bulletForce;

    private void Start() {
        delta = rayon * 0.5f;
        deltaV = new Vector2(delta, 0);
        cPrime = 2*rayon;
    }
    void Update()
    {
        playePos = transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos2 = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonUp("Fire1")) {
            Shoot();
        }
        cursorPos.position = mousePos2;
        designPos();
    }

    void designPos() 
    {
        Vector2 Ca = playePos + deltaV;
        Vector2 Cb = playePos - deltaV;
        float x0 = (Ca.x + Cb.x) / 2;
        float y0 = (Ca.y + Cb.y) / 2;
        float p1= (cPrime + (0.5f * (((Cb.x - Ca.x) * (Cb.x - Ca.x)) + ((Cb.y - Ca.y) * (Cb.y - Ca.y)))));
        float p2 = (2 *(((mousePos2.x - x0) * (mousePos2.x - x0)) + ((mousePos2.y - y0) * (mousePos2.y - y0))));

        float t = Mathf.Sqrt(p1 / p2);
        // Debug.Log(t);
        if (t > 1) {
            cursorPos.position = mousePos2;
        } else {
            cursorPos.position = new Vector2(x0 + t * (mousePos2.x - x0), y0 + t * (mousePos2.y - y0));
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 lookDir = (mousePos - firePoint.position).normalized;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce);
        bullet.GetComponent<bullet>().targetPos = cursorPos.position;
        Debug.Log("SHOOT");
        Debug.Log(cursorPos.position);
    }
}
