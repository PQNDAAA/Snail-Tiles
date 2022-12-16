using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject projectile;
    GameObject player;

    bool canThrowProjectile = true;

    GameObject tmpProjectileSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (canThrowProjectile && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, player.transform.position, Quaternion.identity);
            StartCoroutine(Coldown());
        }
    }

    IEnumerator Coldown()
    {
        canThrowProjectile = false;
        yield return new WaitForSeconds(2);
        canThrowProjectile = true;
    }
}
