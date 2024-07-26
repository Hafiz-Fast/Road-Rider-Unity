using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCrash : MonoBehaviour
{
    [SerializeField] float delay = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("ReloadScene", delay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
