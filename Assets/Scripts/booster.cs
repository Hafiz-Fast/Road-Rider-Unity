using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{
    [SerializeField] SurfaceEffector2D effector;

    void OnTriggerEnter2D(Collider2D collision)
    {
        effector.speed = 50;
    }
}
