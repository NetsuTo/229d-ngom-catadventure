using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float jumpVelocity;

    [SerializeField]
    private Vector3 footOffset;

    [SerializeField]
    private float footRadius;

    [SerializeField]
    private LayerMask groundLayerMask;

    private bool isOnGround;

    private static int PlayerWalkAnimatorHash = Animator.StringToHash("PlayerWalk");

    private static int PlayerJumpAnimatorHash = Animator.StringToHash("PlayerJump");

    static public float moveHorizontal;

    // Update is called once per frame
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CatHurt"))
        {
            rb2d.velocity = Vector2.zero;
            return;
        }
        moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb2d.velocity = new Vector2(moveHorizontal, rb2d.velocity.y);
        Debug.Log(moveHorizontal);

        if (moveHorizontal != 0)
        {
            spriteRenderer.flipX = moveHorizontal < 0;
        }
        Debug.Log(moveHorizontal);

        animator.SetBool(PlayerWalkAnimatorHash, Mathf.Abs(moveHorizontal) > 0);
        animator.SetBool(PlayerJumpAnimatorHash, !isOnGround);

        if (isOnGround && Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
        }
        
    }

    private void FixedUpdate()
    {
        Collider2D hitCollider =  Physics2D.OverlapCircle(transform.position + footOffset, footRadius, groundLayerMask);
        isOnGround = hitCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isOnGround ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position + footOffset, footRadius);
    }
}
