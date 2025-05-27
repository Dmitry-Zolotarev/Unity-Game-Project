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
    public bool isHitted = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public abstract IEnumerator Damage(int damage);
    public abstract void Heal(int healEffect);
    public abstract IEnumerator Die();
}
