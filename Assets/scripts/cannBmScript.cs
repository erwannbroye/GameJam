using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cannBmScript : MonoBehaviour
{
    public Sprite lvl2;
    public GameObject imcache;
    public GameObject text;
    public Level level;
    public int cond;
    string txt2 = "Canon lvl 2";
    string txt3 = "Canon lvl 3";
    // Start is called before the first frame update
    void Start()
    {
        imcache.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(level.coin);
        if (level.coin>=cond) {
            imcache.SetActive(false);
        }
        else
        {
            imcache.SetActive(true);
        }
        if (level.canonLevel>=3) {
            gameObject.SetActive(false);
        }
    }
    public void clicUp () {
        if (level.coin>=cond) {
            level.coin -= cond;
            level.canonLevel ++;
            gameObject.GetComponent<Image>().sprite = lvl2;
            text.GetComponent<UnityEngine.UI.Text>().text = txt2;
            cond += 200;
            level.range+=2;
            level.reloadTime++;
        }
    }
}
