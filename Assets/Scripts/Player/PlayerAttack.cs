using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : Attack
{
    public float range = 2f;
    public float attackCooldown = 1.5f;
    public int damage = 10;
    private Animator animator;
    public bool isAttacking;
        
    public LayerMask enemyLayer;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    public bool IsAttackInput()
    {
        // ПК: левая кнопка мыши
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            return true;
        // Мобильные: касание
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            return true;
        return false;
    }
    public override void DoAttack()
    {
        if (!isAttacking && !isAttacking)
        {
            Collider[] hitObjects = Physics.OverlapSphere(transform.position, range, enemyLayer);
            foreach (Collider collider in hitObjects)
            {
                float angle = Vector3.Angle(transform.forward, (collider.transform.position - transform.position).normalized);

                // Проверка: только перед персонажем (например, в пределах 90 градусов)
                if (angle <= 45f)
                {
                    EnemyHP enemyHP = collider.GetComponent<EnemyHP>();
                    if (enemyHP != null) enemyHP.Damage(damage);
                }
            }

            isAttacking = true;
            StartCoroutine(AttackAnimation());
        }
    }


    private IEnumerator AttackAnimation()
    {
        animator.Play("Boxing");
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
