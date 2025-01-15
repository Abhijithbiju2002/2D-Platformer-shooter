using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public int health = 100;

    private Rigidbody2D myBody;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {;
            ScoreScript.scoreCount += 10;
            Die();
        }
    }
    void Die()
    {
        
        Destroy(gameObject);
       
    }

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2 (speed, myBody.velocity.y);
    }




}//class
