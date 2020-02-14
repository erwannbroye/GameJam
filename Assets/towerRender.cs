using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerRender : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int level = GetComponentInParent<HitCannon>().Level;
        Debug.Log(level);
        if (level == 0) {
            animator.Play("level");
        }
        if (level == 1) {
            animator.Play("level1");
        }
        if (level == 2) {
            animator.Play("level3");
        }
    }
}
