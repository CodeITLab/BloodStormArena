using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarinWarriorAnimations : MonoBehaviour
{
    private Animator barbarinWarriorAnim;

    private void Awake()
    {
        barbarinWarriorAnim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        barbarinWarriorAnim.SetBool(AnimationTag.WALK_PARAMETAR, walk);
    }

    public void WalkBackwards(bool walkBackwards)
    {
        barbarinWarriorAnim.SetBool(AnimationTag.WALK_BACKWARDS_PARAMETAR, walkBackwards);
    }

    public void Sprint(bool sprint)
    {
        barbarinWarriorAnim.SetBool(AnimationTag.SPRINT_FORWARD_PARAMETAR, sprint);
    }

    public void Defend(bool defend)
    {
        barbarinWarriorAnim.SetBool(AnimationTag.DEFEND_PARAMETAR, defend);
    }

    public void Attack_1()
    {
        barbarinWarriorAnim.SetTrigger(AnimationTag.ATTACK_1);
    }

    public void Attack_2()
    {
        barbarinWarriorAnim.SetTrigger(AnimationTag.ATTACK_2);
    }

    public void Attack_3()
    {
        barbarinWarriorAnim.SetTrigger(AnimationTag.ATTACK_3);
    }

    public void Death()
    {
        barbarinWarriorAnim.SetTrigger(AnimationTag.DEATH_PARAMETAR);
    }
}
