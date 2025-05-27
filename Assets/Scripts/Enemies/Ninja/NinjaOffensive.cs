using UnityEngine;

public class NinjaOffensive : Offensive
{
    private EnemyAI AI;
    public void Start()
    {
        AI = GetComponent<EnemyAI>();
    }
    public override void GoToPlayer()
    {
        // Подход к игроку
        Vector3 moveDir = (AI.player.position - transform.position).normalized;
        AI.rigidBody.MovePosition(transform.position + moveDir * AI.moveSpeed * Time.fixedDeltaTime);
        if (!AI.enemyHP.isHitted) AI.animator.Play("Run");
    }
}
