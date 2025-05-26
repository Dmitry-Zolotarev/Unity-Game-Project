using RootMotion.Dynamics;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public abstract class HP : MonoBehaviour
{
    public PuppetMaster ragDoll;
    protected Animator animator;
    public int Value = 100;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public abstract void Damage(int damage);
    public abstract void Heal(int healEffect);
    public abstract IEnumerator Die();
}
