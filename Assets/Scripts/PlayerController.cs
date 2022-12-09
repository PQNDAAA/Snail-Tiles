using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int currentRoadIndex = 0;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoadIndex > -1 && Input.GetKeyDown(KeyCode.Q))
        {
            SubstractActorLocationX(5);
        }
        if (currentRoadIndex < 1 && Input.GetKeyDown(KeyCode.D))
        {
            AddActorLocationX(5);
        }
    }

    void AddActorLocationX(int index)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + index, 0, 0);
        currentRoadIndex++;
    }
    void SubstractActorLocationX(int index)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - index, 0, 0);
        currentRoadIndex--;
    }

    

}
