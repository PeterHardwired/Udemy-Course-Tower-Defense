using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{

    public float castleTotalHealth = 100f ;
    [HideInInspector]
    public float castleCurrentHealth;

    public Slider healthSlider;
    public Transform[] attackPoints;

    // Start is called before the first frame update
    void Start()
    {
        castleCurrentHealth = castleTotalHealth;

        healthSlider.maxValue = castleTotalHealth;
        healthSlider.value = castleCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        castleCurrentHealth -= damageToTake;

        if (castleCurrentHealth <= 0 )
        {
            castleCurrentHealth = 0 ;
            gameObject.SetActive(false);
        }

        healthSlider.value = castleCurrentHealth;
    }
}
