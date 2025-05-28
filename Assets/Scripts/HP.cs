using RootMotion.Dynamics;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public abstract class HP : MonoBehaviour
{
    public PuppetMaster ragDoll;
    protected Animator animator;
    [HideInInspector]public int Value;
    public int MaxHP;

    private void Start()
    {
        Value = MaxHP;
        animator = GetComponent<Animator>();
    }
    public abstract void Damage(int damage);
    public abstract void Heal(int healEffect);
    public abstract IEnumerator Die();
}
