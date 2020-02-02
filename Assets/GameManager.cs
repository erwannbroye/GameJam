using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public IsometricPlayerMovementController player;
    public Level level;
    public int gameState;


    public bool canUpgrade(int cost) 
    {
        if (cost <= level.coin) {
            level.coin -= cost;
            return (true);
        }
        return (false);
    }   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void backToMenu() 
    {
        SceneManager.LoadScene("SceneName Here");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
