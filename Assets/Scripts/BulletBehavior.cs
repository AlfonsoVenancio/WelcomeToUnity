using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    Rigidbody rb;

    public float bulletSpeed;// speed of the bullet

    Vector3 direction;// The point the character is aim at

	void Awake () {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;

        rb.AddForce(direction * bulletSpeed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision hit)
    {
        print(hit.transform.tag);
        if (hit.transform.CompareTag("Enemy"))
        {
            // if the bullet collides with a enemy, make damage of 1
            hit.gameObject.SendMessage("Damage",1f);
        }
        if (!hit.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
