using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Uiscore Uiscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag ("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag  ("Enamy"))
        {
            Destroy(collision.gameObject);
            Uiscore.Killc+= 1;
        }
    }
}
