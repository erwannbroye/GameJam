using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinComponent : MonoBehaviour
{
    // Start is called before the first frame update
    float rayon;
    Transform mousePos2;
    Transform player;
    float T0;
    Vector2 playePos;
    float delta;
    float cPrime;
    Vector2 deltaV ;
    float t ;
    int state = 0;
    public bullet test;
    public Level level;
    void Start()
    {
        rayon = 100;
        mousePos2 = transform;
        Vector3 tar = transform.position + new Vector3(1 + Random.Range(-2f, 2f), 1 + Random.Range(-2f, 2f), 0);
        test.target = tar;        
        test.origin = transform.position;
        designPos();
        test.t = t;
        test.init();
        level.coin += 10;
    }

    // Update is called once per frame
    void Update()
    {

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
        float p2 = (((mousePos2.position.x - x0) * (mousePos2.position.x - x0)) + 2 *((mousePos2.position.y - y0) * (mousePos2.position.y - y0)));

        t = rayon * Mathf.Sqrt(p1 / p2);
    }
}
