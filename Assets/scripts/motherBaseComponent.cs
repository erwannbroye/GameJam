using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherBaseComponent : MonoBehaviour
{
    public int aliveTower;
    // public Tower [] Towers;
    public int level = 1;
    public IaShoot shooter;
    
        // Start is called before the first frame update
    void Start()
    {
        setLevel(1);
    }

    void setLevel(int nlevel) {
        level = nlevel;
        if (level == 1) {
            shooter.GetComponent<CircleCollider2D>().radius = 0;
        }
        if (level == 2) {
        }
        if (level == 3) {
        }
        if (level == 4) {
            shooter.GetComponent<CircleCollider2D>().radius = 100;
        }
        if (level == 5) {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
