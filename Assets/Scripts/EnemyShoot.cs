using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //configs
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myCollider;

    public Player player1;
    public Player player2;
    public GameObject bullet;
    [SerializeField] float fireRate = 2f;
    [SerializeField] float distanceToPlayer = 12f;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();

        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        KillEnemy();
    }

    void Shoot()
    {
        if (Mathf.Abs(transform.position.x - player1.transform.position.x) < distanceToPlayer ||
            Mathf.Abs(transform.position.x - player2.transform.position.x) < distanceToPlayer)
        {
            if (Time.time > nextFire)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
    }

    public void KillEnemy()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Weapon")))
        {
            Destroy(gameObject);
        }
    }
}
