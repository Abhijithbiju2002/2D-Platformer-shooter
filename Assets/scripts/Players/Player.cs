using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro.Examples;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 2f;
    
    private float movementX;
    public int health = 100;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";
    public PhotonView view;
    



    //public override void OnNetworkSpawn()
    //{
    //    if (!IsOwner)
    //    {
    //        enabled = false; 
    //        return;
    //    }
    //}
    public void TakeDamage(int pDamage)
    {
        health -= pDamage;
        if (health <= 0)
        {
          
            Die();
        }
    }
    void Die()
    {

        Destroy(gameObject);

    }

    private void Awake()
    {
        
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine) {

            PlayerMoveKeyboard();
            AnimatePlayer();
            PlayerJump();
        }
        
        


     

    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            PlayerJump();
        }

        

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }

    void AnimatePlayer()
    {
        //we are going right side
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
            view.RPC("OnDirectionChange_RIGHT",RpcTarget.Others);
        }
        else if (movementX < 0)
        {
            // we are goin to the left side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
            view.RPC("OnDirectionChange_LEFT", RpcTarget.Others);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }
    [PunRPC]
    void OnDirectionChange_LEFT()
    {

        sr.flipX = true;
    }
    [PunRPC]
    void OnDirectionChange_RIGHT()
    {
        sr.flipX = false;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetTrigger("jumpAnim");
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }

        if (isGrounded == true)
        {
            anim.SetBool("jumpAnim", false);

        }

        else
        {
            anim.SetBool("jumpAnim", true);
        }
    }
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
                isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
                Destroy(gameObject);
        }

        

    }

    



}// class