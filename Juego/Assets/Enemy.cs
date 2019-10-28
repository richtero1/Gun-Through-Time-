using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform FirePoint;

    public float lookRadius = 10f;

    public float fireRate=1.5f; 
    float nextFire;

    public GameObject enemigo;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
        nextFire = Time.time;
        target = GameControl.instance.player.transform;
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            CheckIfTimeToFire();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            ScoreScript.scoreValue += 100;
            Destroy(enemigo);
        }
    }

}
