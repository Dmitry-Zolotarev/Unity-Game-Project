using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float visionRange = 10f;
    
    
    [HideInInspector]public bool isRetreating = false;
    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public float distance;
    [HideInInspector] public Animator animator;
    [HideInInspector] public HP enemyHP;
    public HP PlayerHP;

    [HideInInspector] public Rigidbody rigidBody;
    public Transform player;
    
    public Collider attackTrigger;

    



    private Attack attack;
    private Retreating retreating;
    private Offensive offensive;
    private Patrol patrol;
    
    private void Start()
    {
        attack = GetComponent<Attack>();
        retreating = GetComponent<Retreating>();
        offensive = GetComponent<Offensive>();
        patrol = GetComponent<Patrol>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        enemyHP = GetComponent<HP>();
        if (attackTrigger == null)
        {
            Debug.LogError("Attack Trigger Collider not assigned!");
            return;
        }
        distance = Vector3.Distance(transform.position, player.position);
        
        attackTrigger.isTrigger = true;
    }

    private void FixedUpdate()
    {
        if(enemyHP.Value > 0)
        {
            Vector3 lookAtPlayer = player.position;
            lookAtPlayer.y = transform.position.y;
            transform.LookAt(lookAtPlayer);
            if (player == null || PlayerHP == null || isAttacking) return;

            distance = Vector3.Distance(transform.position, player.position);

            if (distance < visionRange && PlayerHP.Value > 0)
            {
                if (isRetreating)
                {
                    retreating.Retreat();
                }
                else if (distance > GetAttackRange())
                {
                    offensive.GoToPlayer();
                }
                else attack.DoAttack();
            }
            else patrol.DoPatrol();
        }
        
    }
    private float GetAttackRange()
    {
        if (attackTrigger is SphereCollider sphere)
            return sphere.radius;
        return 1f;
    }

    
}
