using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField] 
    private Transform firePosition;

    public float bulletSpeed = 10;
    
    
    [SerializeField] 
    private int Bullet2Shoot = 30;
    
    private int bulletLeft;

    private void Start()
    {
        bulletLeft = Bullet2Shoot;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        if (bulletLeft > 0)
        {
            GameObject firedBullet = Instantiate(bullet, firePosition.position, Quaternion.identity);
            Rigidbody2D bulletRb = firedBullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(firePosition.up * bulletSpeed, ForceMode2D.Impulse);
            var bulletController = bulletRb.GetComponent<BulletController>();
            bulletController.startX = firePosition.position.x;
            bulletController.startY = firePosition.position.y;
            bulletLeft--;
        }
        
    }
}
