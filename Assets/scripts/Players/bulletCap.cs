using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//using Unity.Netcode;

public class bulletCap : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 30f;
    [SerializeField] private float destroyTime = 1f;
    [SerializeField] private LayerMask WhatDestroysBullet;
    
    public GameObject impactEffect;

    AudioManager audioManager;
  

    public int damage = 50;
    public int pDamage = 20;
    private Rigidbody2D rb;

   // public override void OnNetworkSpawn()
   // {
       // if (!IsOwner)
      //  {
          //  enabled = false;
         //   return;
        //}
//}

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetStraightVelocity();
        SetDestroyTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // is the collision within the whatDestroysBullet layerMask
        if((WhatDestroysBullet.value &(1 << collision.gameObject.layer)) > 0)
        {
            //spawn particles
            //play sound fx
            
            //scrrenshake

            //damage enemy
            Monsters monsters = collision.GetComponent<Monsters>();
            Player player = collision.GetComponent<Player>();

            
            //play sound fx
            audioManager.PlaySFX(audioManager.hit);


            if (monsters != null)
            {
                monsters.TakeDamage(damage);
            }
            if (player != null)
            {
                player.TakeDamage(pDamage);
            }
           
            // enemy and object hit effect
             Instantiate(impactEffect, transform.position, transform.rotation);
            


            //destroy the bullet
            Destroy(gameObject);

        }   
    }
    

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * BulletSpeed;
    }

    private void SetDestroyTime() 
    {
        Destroy(gameObject, destroyTime);
        
        
       
    }
}    