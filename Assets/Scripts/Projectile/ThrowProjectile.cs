using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject projectile;
    GameObject player;

    bool canThrowProjectile = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Spawn the projectile with the cooldown 
        if (canThrowProjectile && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, player.transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    //Cooldown between to throw each projectile 
    IEnumerator Cooldown()
    {
        canThrowProjectile = false;
        yield return new WaitForSeconds(4);
        canThrowProjectile = true;
    }
}
