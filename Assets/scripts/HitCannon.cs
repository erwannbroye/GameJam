using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitCannon : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject coinPrefab;

    
    public float MaxHealth = 100f;
    public float CurrentHealth = 100f;
    public float RegenParSecondenemis = 5f;
    
    public Image HealthBar;

    public float MaxUpgrade = 100f;
    public float CurrentUpgrade = 0f;
    public float RegenRepair = 5f;
    public Image UpgradeBar;
    public AudioClip [] efxClips;


   
    private bool isBurning;
    private float DamagesBySecond;
    private float BurningStopTime;


    public bool repair = false;
    private bool upgrading = true;
    public int Level = 0;
    public bool canDamage = true;
    int i = 0;


    public void TakeDamages (float damageTaken)
    {
        if (canDamage) {
            CurrentHealth -= damageTaken;
            if(CurrentHealth <= 0 && upgrading == true)
            {
                upgrading = false;
                CurrentUpgrade = 0;
                repair = true;
                CurrentHealth = 0;
                for (int i = 0; i < 10; i++) {
                    GameObject bullet = Instantiate(coinPrefab, transform.position, transform.rotation);
                }
            }
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
        CurrentUpgrade += RegenRepair * Time.deltaTime / 2;
        

        if (CurrentUpgrade >=100f)
        {
            if (Level < 4)
            {
                Level += 1;
                Debug.Log("Level up " + Level);
                CurrentUpgrade = 0;
                CurrentHealth *= 1.5f;
                MaxHealth *= 1.5f;
                GetComponentInChildren<IaShoot>().reloadTime -= 0.5f;
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
         
        if (CurrentHealth > 10)
            i =0;
        if (CurrentHealth <= 0) {
            CurrentHealth = 0;
            int tmp = Mathf.RoundToInt(Random.Range(0, 2));
            if (i == 0) {
                GetComponent<AudioSource>().PlayOneShot(efxClips[tmp], 1f);
                GetComponent<AudioSource>().PlayOneShot(efxClips[3], 1f);

            }
            i = 1;
        }
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
            int tmp = Mathf.RoundToInt(Random.Range(2, 3));
            GetComponent<AudioSource>().PlayOneShot(efxClips[tmp], 1f);
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
