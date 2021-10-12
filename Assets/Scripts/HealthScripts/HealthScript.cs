using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private BarbarinWarriorAnimations animations;
    private float lerpTimer;
    private float maxHealth = 100;
    public float health;
    public bool isBarbarinWarrior;
    public float chipSpeed;

    [SerializeField]
    private Image healthValue;
    [SerializeField]
    private Image damageValue;

    private void Awake()
    {
        animations = GetComponent<BarbarinWarriorAnimations>();
        health = maxHealth;
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);


        float fillHealthValue = healthValue.fillAmount;
        float fillDamageValue = damageValue.fillAmount;
        float healthFraction = health / maxHealth;

        if (fillDamageValue > healthFraction)
        {
            healthValue.fillAmount = healthFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            damageValue.fillAmount = Mathf.Lerp(fillDamageValue, healthFraction, percentComplete);
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;

        if(health <= 0)
        {
            //GetComponent<Animator>().enabled = false;
            animations.Death();

            if(isBarbarinWarrior)
            {
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<BarbarinWarriorAttackInput>().enabled = false;
                GameObject.FindGameObjectWithTag(Tags.BARBARIN_OPPONENT_TAG).GetComponent<BarbarinWarriorAIController>().enabled = false;
            }
            else
            {
                GetComponent<BarbarinWarriorAIController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }
}
