using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        StartCoroutine(DeathAfterSecond(5));
    }
    
    void Update()
    {
        //Direction of the projectile
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z + -0.01f);
    }

    //Collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            scoreManager.AddMultiplier(0.1f);
            Destroy(other.gameObject);
        }
    }

    //Destroy the projectile
    IEnumerator DeathAfterSecond(int seconde)
    {
        yield return new WaitForSeconds(seconde);
        Destroy(gameObject);
    }
}
