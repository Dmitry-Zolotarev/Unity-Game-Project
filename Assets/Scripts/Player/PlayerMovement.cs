using RootMotion.Dynamics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private PlayerAttack attack; 
    private Animator animator;
    private Rigidbody body;

    private bool isGrounded;
    private HP playerHP;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        playerHP = GetComponent<HP>();
        animator = GetComponent<Animator>();
        attack = GetComponent<PlayerAttack>();
    }
    
    void FixedUpdate()
    {
        if (isGrounded && playerHP.Value > 0)
        {
            if (attack.IsAttackInput()) attack.DoAttack();
            float moveX = 0f;
            if (Keyboard.current.aKey.isPressed) moveX -= 1f;
            if (Keyboard.current.dKey.isPressed) moveX += 1f;
            Vector3 direction = new Vector3(moveX, 0, 0);
            if (direction.magnitude > 0f)
            {
                body.MovePosition(transform.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);
                transform.rotation = Quaternion.Euler(0, moveX > 0 ? 90 : -90, 0);
                if (!attack.isAttacking) animator.Play("Run");
            }
            else if (Keyboard.current.spaceKey.wasPressedThisFrame) Jump();
            else if (!attack.isAttacking) animator.Play("Idle");

            if (Keyboard.current.spaceKey.isPressed) Jump();
        }
        
    }
    void Jump()
    {
        body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        animator.Play("Jump");
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
