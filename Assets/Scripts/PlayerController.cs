using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int currentRoadIndex = 0;
    public float lerpDuration = 2f;

    Vector3 positionToMoveTo;
    bool movementIsFinished = true;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementIsFinished && currentRoadIndex > -1 && Input.GetKeyDown(KeyCode.D))
        {
            SubstractActorLocationX(5);
        }
        if (movementIsFinished && currentRoadIndex < 1 && Input.GetKeyDown(KeyCode.Q))
        {
            AddActorLocationX(5);
        }
    }


    
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        movementIsFinished = false;
        float time = 0;
        float t ;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            t = time / duration;
            //Smooth Step Lerp Math Formula
            t = t * t * (3f - 2f * t);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        movementIsFinished = true;
    }

    void AddActorLocationX(int index)
    {
        positionToMoveTo = new Vector3(gameObject.transform.position.x + index, 1, 0);
        StartCoroutine(LerpPosition(positionToMoveTo, lerpDuration));
        currentRoadIndex++;
    }
    void SubstractActorLocationX(int index)
    {
        positionToMoveTo = new Vector3(gameObject.transform.position.x - index, 1, 0);
        StartCoroutine(LerpPosition(positionToMoveTo, lerpDuration));
        currentRoadIndex--;
    }

    

}
