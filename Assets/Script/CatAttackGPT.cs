using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttackGPT : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to be shot
    public Transform firePoint; // The position from where bullets are shot
    public float minForce = 10f; // The minimum force to shoot the bullet
    public float maxForce = 100f; // The maximum force to shoot the bullet
    public float forceIncrement = 10f; // The increment of force when holding the shoot button
    private float currentForce; // The current force to shoot the bullet

    // Update is called once per frame
    void Update()
    {
        // Increase the force while holding the shoot button
        if (Input.GetKey(KeyCode.Z))
        {
            IncreaseForce();
        }

        // Shoot the bullet when releasing the shoot button
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Shoot();
        }
    }

    // Increase the force when holding the shoot button
    void IncreaseForce()
    {
        currentForce = Mathf.Clamp(currentForce + forceIncrement * Time.deltaTime, minForce, maxForce);
    }

    // Shoot the bullet
    void Shoot()
    {
        if (CatMove.moveHorizontal == 8)
        {
            currentForce = currentForce;
        }
        else if (CatMove.moveHorizontal == -8)
        {
            currentForce = -currentForce;
        }

        // Instantiate a new bullet at the firePoint position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Calculate the direction to shoot the bullet
        Vector2 shootDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        // Apply force to shoot the bullet in the calculated direction
        rb.AddForce(shootDirection * currentForce, ForceMode2D.Impulse);

        // Reset the force back to the minimum value after shooting
        currentForce = minForce;
    }
}
