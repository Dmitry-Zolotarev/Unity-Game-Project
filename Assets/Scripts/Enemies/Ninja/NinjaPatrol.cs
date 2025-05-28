
public class NinjaPatrol : Patrol
{
    private EnemyAI AI;
    public void Start()
    {
        AI = GetComponent<EnemyAI>();
    }
    public override void DoPatrol()
    {
        AI.animator.Play("Idle");
    }
}
