﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 50;
    public float damage = 15;
    AudioSource audioSource;
    public AudioClip laserHit;
    public AudioClip fireLaser;
    public AudioClip shipDestroy;

    [SerializeField]
    GameObject explosion;
    PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (PV != null && PV.IsMine)
        {

            if (collision.gameObject.tag == "Player")
            {
                //Damage player
                GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(laserHit);
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
