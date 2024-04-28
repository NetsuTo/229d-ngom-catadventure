using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // เลือกประเภทของโปรเจคไบรต์ที่จะยิง
    public Transform firePoint; // ตำแหน่งที่จะให้ bullet แสดงออกมา
    public float minForce = 10f; // แรงขั้นต่ำ
    public float maxForce = 100f; // แรงสูงสุด
    public float forceIncrement = 10f; // ปริมาณที่เพิ่มขึ้นเมื่อค้างปุ่ม
    private float currentForce; // แรงปัจจุบันที่จะยิง

    // Update is called once per frame
    void Update()
    {
        // กดปุ่ม Z เพื่อเพิ่มแรง
        if (Input.GetKey(KeyCode.Z))
        {
            IncreaseForce();
        }

        // ปล่อยปุ่ม Z เพื่อยิง
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Shoot();
        }
    }

    // เพิ่มแรงเมื่อปุ่มถูกกด
    void IncreaseForce()
    {
        currentForce = Mathf.Clamp(currentForce + forceIncrement * Time.deltaTime, minForce, maxForce);
    }

    // ยิง
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the direction based on the character's facing direction
        Vector2 direction = transform.localScale.x > 0 ? transform.right : -transform.right;

        // Flip the bullet's sprite if character is facing left
        if (transform.localScale.x < 0)
        {
            bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * -1, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Set bullet's velocity to move in the direction the character is facing
        rb.velocity = direction.normalized * currentForce;

        currentForce = minForce; // Reset the force back to the minimum value after shooting
    }

}
