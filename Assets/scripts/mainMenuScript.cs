using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject content;
    public GameObject voidtop;
    public GameObject start;
    public GameObject option;
    public GameObject control;
    public GameObject credit;
    public GameObject quite;
    public GameObject voiddown;
    public Button selectButton;
    public Button selectButton2;
    private Vector3 startingPosition;
	//public Transform followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    public float taille;
    // Start is called before the first frame update
    Vector3 followTarget;
    float posy;
    float tempcol;
    void Start()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille*3);
        content.GetComponent<RectTransform>().localPosition = new Vector3(0,taille*-2,0);
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille*7);
        voidtop.GetComponent<RectTransform>().localPosition = new Vector3(0,taille*3,0);
        voidtop.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille);
        start.GetComponent<RectTransform>().localPosition = new Vector3(0,taille*2,0);
        start.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille);
        option.GetComponent<RectTransform>().localPosition = new Vector3(0,taille*1,0);
        option.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille);
        control.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        control.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille);
        credit.GetComponent<RectTransform>().localPosition = new Vector3(0,taille*-1,0);
        credit.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille);
        quite.GetComponent<RectTransform>().localPosition = new Vector3(0,taille*-2,0);
        quite.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille);
        voiddown.GetComponent<RectTransform>().localPosition = new Vector3(0,taille*-3,0);
        voiddown.GetComponent<RectTransform>().sizeDelta = new Vector2(taille*4,taille);
        followTarget = new Vector3(0f,-taille*2,0f);
        startingPosition = content.GetComponent<RectTransform>().localPosition;
        selectButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        posy = content.GetComponent<RectTransform>().localPosition.y;
        //Pos = content.GetComponent<RectTransform>().localPosition;
        if (Input.GetKeyDown(KeyCode.DownArrow) && posy + followTarget.y <= taille*2+11) {
            followTarget.y += taille;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && posy + followTarget.y >= -taille*2-11) {
            followTarget.y -= taille;
        }
        //content.GetComponent<RectTransform>().localPosition = Pos;
        if(followTarget != null)
        {
            targetPos = new Vector3(followTarget.x, followTarget.y, 0);
            Vector3 velocity = (targetPos - content.GetComponent<RectTransform>().localPosition) * moveSpeed;
            content.GetComponent<RectTransform>().localPosition = Vector3.SmoothDamp (content.GetComponent<RectTransform>().localPosition, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
        if (posy <= taille*2) {
            tempcol = -posy/(taille*2);
            start.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }
        if (posy <=-taille) {
            tempcol = (posy+taille*3)/(taille*2);
            option.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }
        if (posy >-taille && posy <=taille*2) {
            tempcol = (-posy+taille)/(taille*2);
            option.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }
        if (posy <=0) {
            tempcol = (posy+taille*2)/(taille*2);
            control.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }

        if (posy >0) {
            tempcol = (-posy+taille*2)/(taille*2);
            control.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }
        if (posy >-taille*2 && posy <=taille) {
            tempcol = (posy+taille)/(taille*2);
            credit.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }
        if (posy >taille) {
            tempcol = (-posy+taille*3)/(taille*2);
            credit.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }
        if (posy >-taille*2) {
            tempcol = (posy)/(taille*2);
            quite.GetComponent<Image>().color = new Color(0,0,0,tempcol);
        }
    }
    public void OptionBm () {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        selectButton2.Select();
        print("go option");
    }
    public void StartBm () {
        print("jeux lancé !");
    }
    public void QuiteBm () {
        print("on quite le jeux !");
    }
}
