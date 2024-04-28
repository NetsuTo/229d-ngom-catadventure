using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatDead : MonoBehaviour
{
    public int health;
    public bool hasDied;
    private Uiscore Uiscore;
    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            hasDied |= true;

        }
        if (hasDied == true)
        {
            StartCoroutine("Die");
            Uiscore.Killc = 0;
        }

    }

    IEnumerator Die()
    {
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
