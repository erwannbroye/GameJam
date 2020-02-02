using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitCannon : MonoBehaviour
{
    public GameObject Bullet;
    
    public float MaxHealth = 100f;
    public float CurrentHealth = 100f;
    public float RegenParSecondenemis = 5f;
    
    public Image HealthBar;

    public float MaxUpgrade = 100f;
    public float CurrentUpgrade = 0f;
    public float RegenRepair = 5f;
    public Image UpgradeBar;

   
    private bool isBurning;
    private float DamagesBySecond;
    private float BurningStopTime;


    private bool repair = false;
    private bool upgrading = true;
    private int Level = 0;


    public void TakeDamages (float damageTaken)
    {
        CurrentHealth -= damageTaken;
        if(CurrentHealth <= 0)
        {
            upgrading = false;
            CurrentUpgrade = 0;
            repair = true;
            CurrentHealth = 0;
        }
        
        
    }

    public void TakeDamagesOvertime(float duration,float damage)
    {
        isBurning = true;
        BurningStopTime = Time.time + duration;
        DamagesBySecond = damage / duration;
        


    }

    public void TowerUpgrade()
    {
        CurrentUpgrade += RegenRepair * Time.deltaTime;
        

        if (CurrentUpgrade >=100f)
        {
            if (Level < 4)
            {
                Level += 1;
                Debug.Log("Level up " + Level);
                CurrentUpgrade = 0;
            }
            
        }
    }

    public void RegenHealth()
    {
        CurrentHealth += RegenParSecondenemis * Time.deltaTime;
        
        if (CurrentHealth >= 100)
        {
            upgrading = true;
            CurrentUpgrade = 0;
            repair = false;
            CurrentHealth = 100;
        }


    }
    


    // Update is called once per frame
    void Update()
    {
        if (repair)
        {
            RegenHealth();
        }
       
        if (upgrading)
        {
            TowerUpgrade();

        }
       
        if (CurrentUpgrade >= 100)
        {
            CurrentUpgrade = 100;
        }

        if (isBurning)
        {
            TakeDamages(DamagesBySecond * Time.deltaTime);
            if(Time.time >= BurningStopTime)
            {
                isBurning = false;
            }
        }

        UpdateDisplay();
        
    }

    void UpdateDisplay()
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
        UpgradeBar.fillAmount = CurrentUpgrade / MaxUpgrade;
    }

   
    

}
