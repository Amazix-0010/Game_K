using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    public Rigidbody theRB;

    public float lifeTime = 2f;

    public GameObject bulletparticle;

    public int damage;

    public bool damageEnemy, damagePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.forward * speed;

        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && damageEnemy == true)
        {
            // Destroy(other.gameObject);

            other.gameObject.GetComponent<EnemyHealth>().DamageEnemy(damage);
        }

        if(other.gameObject.tag == "Player" && damagePlayer)
        {
            Debug.Log("Zásah hráče " + transform.position);
        }
               
            Destroy(gameObject);
            Instantiate(bulletparticle, transform.position + (transform.forward * (-speed * Time.deltaTime)), transform.rotation);
        
    }
}
