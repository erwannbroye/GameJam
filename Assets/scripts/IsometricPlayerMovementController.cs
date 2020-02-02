using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    public IsometricCharacterRenderer isoRenderer2;

    Rigidbody2D rbody;
    public Rigidbody2D firePoint;
    public Camera cam;
    Vector2 mousePos;
    public float MaxHealth = 100f;
    public float CurrentHealth = 100f;
    public Image HealthBar;
    Level level;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        level = GetComponent<Level>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    public void TakeDamages (float damageTaken)
    {
        CurrentHealth -= damageTaken;
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }  
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * level.speed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        isoRenderer2.SetDirection(movement);
        rbody.MovePosition(newPos);
        firePoint.MovePosition(newPos);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) *  Mathf.Rad2Deg - 90f;
        firePoint.rotation = angle;
        UpdateDisplay();

    }

        void UpdateDisplay()
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
