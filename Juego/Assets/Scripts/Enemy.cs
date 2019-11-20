using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform FirePoint;

    public float lookRadius = 8f;

    public float fireRate=1.5f; 
    float nextFire;

    public GameObject enemigo;

    private Transform target;
 
    private  Renderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        nextFire = Time.time;
        target = GameControl.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, lookRadius);
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < lookRadius)
        {
<<<<<<< HEAD
            CheckIfTimeToFire();
        }
        if (hitinfo.collider != null)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            Debug.DrawLine(transform.position, hitinfo.point, Color.blue);
            if (hitinfo.collider.CompareTag("Player"))
            {
                
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * lookRadius, Color.yellow);
        }
       
=======
            
            CheckIfTimeToFire();
        }
>>>>>>> parent of 4c3160b... push para hacer pull
=======
            
            CheckIfTimeToFire();
        }
>>>>>>> parent of 4c3160b... push para hacer pull
=======
            
            CheckIfTimeToFire();
        }
>>>>>>> parent of 4c3160b... push para hacer pull
        
    }

    

    void CheckIfTimeToFire()
    {
        
        if (Time.time > nextFire)
        {
            
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
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
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
        Quaternion bRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Instantiate(bulletPrefab, FirePoint.position, bRotation);
    }

    


}
