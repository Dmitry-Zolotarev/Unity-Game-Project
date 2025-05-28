using RootMotion.Dynamics;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHP : HP
{
    
    public TextMeshProUGUI HPLabel, GameOver;
    public float deathTime;
    private void Start()
    {
        HPLabel.text = "HP: " + Value;
    }
    public override void Damage(int damage)
    {
        Value -= damage;
        if (Value < 0) Value = 0;
        HPLabel.text = "HP: " + Value;
        if (Value == 0) StartCoroutine(Die());
    }
    public override void Heal(int heal)
    {
        Value += heal;
        if (Value > MaxHP) Value = MaxHP;
        HPLabel.text = "HP: " + Value;
    }
    public override IEnumerator Die()
    {
        ragDoll.mode = PuppetMaster.Mode.Active;
        ragDoll.state = PuppetMaster.State.Dead;
        yield return new WaitForSeconds(deathTime);
        GameOver.text = "Game Over!";
        Time.timeScale = 0;
    }
}
