using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;

    Vector3 direction;

    public float enemySpeed;

    public float enemyLife;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // when the enemy spawns, make it move
        ChangeDirection(direction,enemySpeed*3);
    }


    public void Damage(float damage)
    {
        enemyLife -= damage;
        if (enemyLife<=0)
        {
            // when a enemy dies, call the EnemyDown and MiniExplotion methods of the game manager and destroy the enemy
            GameManager.instance.EnemyDown();
            GameManager.instance.MiniExplotion(transform.position);
            Destroy(gameObject);
        }
    }
    
    public void ChangeDirection(Vector3 _direction, float force)
    {
        force = (force > 0f) ? force:enemySpeed;
        /* remeber this line above is equivalent to:
         * 
         * if (force > 0f){
         *  force = force;
         * }else{
         *  force = enemySpeed;
         * }
         */
        direction =( new Vector3(_direction.x,transform.position.y, _direction.z)- transform.position).normalized;
        rb.AddForce(direction*force);
    }

    void OnCollisionEnter(Collision hit)
    {

        if (hit.transform.CompareTag("Bullet"))
        {
            //change the direction to the opposite direction of the bullet
            ChangeDirection(-hit.transform.position, 6);
            StartCoroutine(KnockBack());
        }
        else if (hit.transform.CompareTag("Wall") || hit.transform.CompareTag("Enemy"))
        {
            //if the enemy colides with a wall or another enemy, change the direction and mantain the same speed
            ChangeDirection(GameManager.instance.player.transform.position, enemySpeed);
        }
    }

    IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(1.25f);
        ChangeDirection(GameManager.instance.player.transform.position, enemySpeed);
    }

}