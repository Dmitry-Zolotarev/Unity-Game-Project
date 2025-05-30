using RootMotion.Dynamics;
using System.Collections;
using UnityEngine;

public class EnemyHP : HP
{
    public override void Damage(int damage)
    {
        Value -= damage;
        if (Value < 0) Value = 0;
        if (Value == 0) StartCoroutine(Die());
        Debug.Log("Enemy HP: " + Value);
    }

    public override IEnumerator Die()
    {
        ragDoll.mode = PuppetMaster.Mode.Active;
        ragDoll.state = PuppetMaster.State.Dead;
        yield return null;
    }

    public override void Heal(int heal)
    {
        
        Value += heal;
        if (Value > MaxHP) Value = MaxHP;
    }
}
