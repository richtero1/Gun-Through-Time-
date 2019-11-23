using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Joystick j2;
    public float fireRate= 0.5f;
    float nextFire;
    public float bulletForce = 10f;
    

    void Start()
    {
        
        nextFire = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        //if(GameControl.health == 2)
        //{
        //    fireRate= 0.01f;
        //}


        if (!j2.Horizontal.Equals(0)|| !j2.Vertical.Equals(0))
        {
            CheckIfTimeToFire();
            //Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        }else if ( Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 moveDirection = new Vector3(j2.Horizontal, j2.Vertical, 0).normalized;
        float randomSpread = Random.Range(-5, 5);
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
        Quaternion bRotation = Quaternion.Euler(new Vector3(0, 0, angle + randomSpread));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bRotation) as GameObject;
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