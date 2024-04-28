using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedhatWalk : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public float walkSpeed = 2f; // ��������㹡���Թ
    private Rigidbody2D rb; // ��ҧ�ԧ Rigidbody2D �ͧ����Ф�
    private bool isWalkingForward = true; // ���������Ѻ��Ǩ�ͺ��ҵ���Фá��ѧ�Թ仢�ҧ˹���������

    void Start()
    {
        // �Ѻ��� Rigidbody2D ���Ṻ�ҡѺ����Ф�
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���¡��ѧ��ѹ�Թ
        Walk();
    }

    void Walk()
    {
        // ��Ǩ�ͺ��ҵ���Фá��ѧ�Թ仢�ҧ˹���������
        if (isWalkingForward)
        {
            spriteRenderer.flipX = isWalkingForward;
            // ����͹���价ҧ���
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        else
        {
            spriteRenderer.flipX = isWalkingForward;
            // ����͹���价ҧ����
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ��ҵ���Фê����úҧ���ҧ���Ͷ֧�ͺ��� �������¹��ȷҧ����Թ
        isWalkingForward = !isWalkingForward;
    }
}
