using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarinWarriorAttackInput : MonoBehaviour
{
    private BarbarinWarriorAnimations barbarinAnimation;

    public GameObject attackPoint;

    private void Awake()
    {
        barbarinAnimation = GetComponent<BarbarinWarriorAnimations>();
    }

    private void Update()
    {
        // defend
        /*if(Input.GetKey(KeyCode.LeftAlt))
        {
            barbarinAnimation.Defend(true);
        }
        else
        {
            barbarinAnimation.Defend(false);
        }*/

        // attack1
        if(Input.GetKeyDown(KeyCode.J))
        {
            barbarinAnimation.Attack_1();
        }

        // attack2
        if(Input.GetKeyDown(KeyCode.K))
        {
            barbarinAnimation.Attack_2();
        }

        // attack3
        //...
    }

    private void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    private void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
