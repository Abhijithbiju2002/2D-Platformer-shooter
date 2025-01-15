using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
//using Photon.Pun.Demo.Asteroids;
//using Unity.Netcode;

public class PlayerAim : MonoBehaviourPun
{
    [SerializeField] private GameObject gun;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    private GameObject bulletInst;
    AudioManager audioManager;


    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    public PhotonView view;
    //Bullet Bullet;

    
    private void Start()
    {
        view = GetComponent<PhotonView>();
        //Bullet
    }




    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (view.IsMine)
        {
            HandleGunRotation();

            HandleGunShooting();
        }
        

    }

    [PunRPC]
    private void HandleGunRotation()
    {
        //rotate the gun towards the mouse position
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        //flip the gun when it reaches a 90 degree threshold
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(0.86f, 0.86f, 0.86f);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -0.86f;
        }
        else {
            localScale.y = 0.86f;

        }

        gun.transform.localScale = localScale;

    }
    private void HandleGunShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            //spawn bullet
            bulletInst =Instantiate(bulletPrefab, bulletSpawnPoint.position, gun.transform.rotation);

            audioManager.PlaySFX(audioManager.shoot);
           


        }
        


    }
    



}
