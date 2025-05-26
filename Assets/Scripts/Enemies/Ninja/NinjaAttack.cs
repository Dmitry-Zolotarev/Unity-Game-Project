using System.Collections;
using UnityEngine;

public class NinjaAttack : Attack
{
    private EnemyAI AI;
    public int damage;
    public float attackCooldown = 1.5f;
    
    public void Start()
    {
        AI = GetComponent<EnemyAI>();
    }
    public override void DoAttack()
    {
        if (!AI.isAttacking) StartCoroutine(AttackAnimation());
    }
    private IEnumerator AttackAnimation()
    {

        // ¬рем€ должно соответствовать длине анимации "Boxing"
        AI.isAttacking = true;
        AI.animator.Play("Boxing");
        yield return new WaitForSeconds(attackCooldown / 2f);
        AI.PlayerHP.Damage(damage);
        yield return new WaitForSeconds(attackCooldown / 2f);
        AI.isAttacking = false;
        AI.isRetreating = true;
    }
}

