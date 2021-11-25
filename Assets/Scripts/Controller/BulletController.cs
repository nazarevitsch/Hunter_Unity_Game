using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float startX;
    public float startY;

    public float maxBulletDistance ;

    private void Update()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - startX, 2) +
                                    Mathf.Pow(gameObject.transform.position.y - startY, 2));
        if (distance > maxBulletDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
