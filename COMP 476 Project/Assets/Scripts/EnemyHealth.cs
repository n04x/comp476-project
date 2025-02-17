﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    private PhotonView PV;
    public int current_hp;
    private void Start()
    {
        current_hp = GetComponent<EnemyStateController>().enemy_stats.max_hp;
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (current_hp <= 0)
            {
                Debug.LogWarning("Should be dead");

                PV.RPC("Die", RpcTarget.All);
            }
            //Error here 
            //PV.RPC("EnemyHP", RpcTarget.Others, current_hp);
        }
    }
    [PunRPC]
    void EnemyHP(int h)
    {
        current_hp = h;
    }
    public void TakeDamage()
    {
        
            current_hp--;
       
      
            PV.RPC("EnemyHP", RpcTarget.All, current_hp);
       

    }
    [PunRPC]
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
