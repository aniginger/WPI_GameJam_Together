using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking;
    [SerializeField] private float attackTimer = 0f;
    [SerializeField] private float attackCooldown = 0.3f;
    [SerializeField] bool canAttack;

    public Collider2D attackTrigger;

    private void Awake()
    {
        attackTrigger.enabled = false;
    }

    private void Update()
    {
        BasicAttack();
    }

    void BasicAttack()
    {
        if (CrossPlatformInputManager.GetButtonDown("Attack") && !attacking && canAttack)
        {
            attacking = true;
            attackTimer = attackCooldown;
            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attackTimer = 0;
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}