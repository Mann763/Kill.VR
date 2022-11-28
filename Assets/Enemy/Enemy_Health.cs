using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Transform cam;
    public Transform centerPoint;

    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    public HealthBar healthBar;


    private void LateUpdate()
    {
        transform.LookAt(cam.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();

        this.transform.parent = centerPoint;

        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount, Vector3 direction)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        //Damage_popup popup = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<Damage_popup>();
        //popup.SetDamageText(amount);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //ragdoll.ActivateRagdoll();
        Destroy(this.gameObject);
        //healthBar.gameObject.SetActive(false);
    }
}
