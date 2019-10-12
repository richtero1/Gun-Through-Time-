using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Joystick j2;
    float fireRate;
    float nextFire;
    public float bulletForce = 10f;

    void Start()
    {
        fireRate = .5f;
        nextFire = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (!j2.Horizontal.Equals(0)|| !j2.Vertical.Equals(0))
        {
            CheckIfTimeToFire();
            //Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse) ;
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }
}