using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // ���͡�������ͧ��ਤ�õ�����ԧ
    public Transform firePoint; // ���˹觷������ bullet �ʴ��͡��
    public float minForce = 10f; // �ç��鹵��
    public float maxForce = 100f; // �ç�٧�ش
    public float forceIncrement = 10f; // ����ҳ��������������ͤ�ҧ����
    private float currentForce; // �ç�Ѩ�غѹ�����ԧ

    // Update is called once per frame
    void Update()
    {
        // ������ Z ���������ç
        if (Input.GetKey(KeyCode.Z))
        {
            IncreaseForce();
        }

        // ����»��� Z �����ԧ
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Shoot();
        }
    }

    // �����ç����ͻ����١��
    void IncreaseForce()
    {
        currentForce = Mathf.Clamp(currentForce + forceIncrement * Time.deltaTime, minForce, maxForce);
    }

    // �ԧ
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
