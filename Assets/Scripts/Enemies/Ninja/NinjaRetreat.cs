using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public  class NinjaRetreat : Retreating
{
    private EnemyAI AI;
    public float retreatDistance = 1.5f;
    public float waitTime = 0.5f;
    public void Start()
    {
        AI = GetComponent<EnemyAI>();
    }
    public override void Retreat()
    {
        if (AI.distance < retreatDistance)
        {
            Vector3 direction = (transform.position - AI.player.position).normalized;
            AI.rigidBody.MovePosition(transform.position + direction * AI.moveSpeed * Time.fixedDeltaTime);
            if (!AI.enemyHP.isHitted) AI.animator.Play("Walk Backwards");
        }
        else StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        if (!AI.enemyHP.isHitted) AI.animator.Play("Idle");
        yield return new WaitForSeconds(waitTime);
        AI.isRetreating = false;
    }
}
