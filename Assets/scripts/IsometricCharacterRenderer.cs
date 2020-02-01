using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IsometricCharacterRenderer : MonoBehaviour
{

    public string[] staticDirections;
    public string[] runDirections;

    Animator animator;
    int lastDirection;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void SetDirection(Vector2 direction){

        string[] directionArray = null;

        if (direction.magnitude < .01f)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 4);
        }

        animator.Play(directionArray[lastDirection]);
    }


    public static int DirectionToIndex(Vector2 dir, int sliceCount){
        Vector2 normDir = dir.normalized;
        float step = 360f / sliceCount;
        float halfstep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += halfstep;
        if (angle < 0){
            angle += 360;
        }
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }


    public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
    {
        int[] hashArray = new int[animationArray.Length];
        for (int i = 0; i < animationArray.Length; i++)
        {
            hashArray[i] = Animator.StringToHash(animationArray[i]);
        }
        return hashArray;
    }

}
