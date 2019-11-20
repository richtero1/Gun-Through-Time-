using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgun : MonoBehaviour
{
    public Transform FirePoint;

    public float lookRadius = 10f;

    public float fireRate = 1.5f;
    float nextFire;

    public GameObject enemigo;

    private Transform target;

    //Variables para el Spread
    public GameObject bulletPrefab;
    public int pellets = 1;
    public float spread;

    private Renderer m_renderer;

    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        nextFire = Time.time;
        target = GameControl.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && m_renderer.isVisible)
        {
            CheckIfTimeToFire();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius/2);
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            float totalSpread = spread / pellets;

            for (int i = 0; i < pellets; i++)
            {
                fireBullet();
            }


            /*for (int i = 0; i < pellets; i++)
            {
                Instantiate(bulletPrefab, FirePoint.position, Quaternion.identity);
            }*/

            nextFire = Time.time + fireRate;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("BulletPlayer"))
        {
            ScoreScript.scoreValue += 100;
            Destroy(enemigo);
        }
    }

    private void fireBullet()
    {

       

        Vector3 moveDirection = (target.position - FirePoint.position).normalized;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg ;

        float randomSpread = Random.Range(-spread, spread);
        Quaternion bRotation = Quaternion.Euler(new Vector3(0, 0, angle + randomSpread));
         Instantiate(bulletPrefab, FirePoint.position, bRotation);
        

    }
}
