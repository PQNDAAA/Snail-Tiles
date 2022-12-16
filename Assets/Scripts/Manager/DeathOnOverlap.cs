using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnOverlap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

    }
}
