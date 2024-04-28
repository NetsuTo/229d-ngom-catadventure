using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedhatWalk : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public float walkSpeed = 2f; // ความเร็วในการเดิน
    private Rigidbody2D rb; // อ้างอิง Rigidbody2D ของตัวละคร
    private bool isWalkingForward = true; // ตัวแปรสำหรับตรวจสอบว่าตัวละครกำลังเดินไปข้างหน้าหรือไม่

    void Start()
    {
        // รับค่า Rigidbody2D ที่แนบมากับตัวละคร
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // เรียกใช้ฟังก์ชันเดิน
        Walk();
    }

    void Walk()
    {
        // ตรวจสอบว่าตัวละครกำลังเดินไปข้างหน้าหรือไม่
        if (isWalkingForward)
        {
            spriteRenderer.flipX = isWalkingForward;
            // เคลื่อนที่ไปทางขวา
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        else
        {
            spriteRenderer.flipX = isWalkingForward;
            // เคลื่อนที่ไปทางซ้าย
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ถ้าตัวละครชนอะไรบางอย่างหรือถึงขอบแมพ ก็จะเปลี่ยนทิศทางการเดิน
        isWalkingForward = !isWalkingForward;
    }
}
