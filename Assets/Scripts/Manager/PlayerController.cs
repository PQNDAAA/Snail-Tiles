using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int currentRoadIndex = 0;
    public float lerpDuration = 2f;
    public float rotateSpeed = 10f;

    Vector3 positionToMoveTo;
    bool movementIsFinished = true;

    void Update()
    {
        //Right movement
        if (movementIsFinished && currentRoadIndex > -1 && Input.GetKeyDown(KeyCode.D))
        {
            SubstractActorLocationX(5);
        }
        //Left movement
        if (movementIsFinished && currentRoadIndex < 1 && Input.GetKeyDown(KeyCode.Q))
        {
            AddActorLocationX(5);
        }
    }

    //The smooth movement when the player must go to the new position 
    //Avoid the basic teleportation effect 
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        //isFinished false
        movementIsFinished = false;

        float time = 0;
        float t ;

        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            t = time / duration;
            //Smooth Step Lerp Math Formula
            t = t * t * (3f - 2f * t);
            //Lerp between the start & target position 
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPosition;
        //IsFinished true
        movementIsFinished = true;
    }

    //The player goes to the new road / Left
    void AddActorLocationX(int index)
    {
        positionToMoveTo = new Vector3(gameObject.transform.position.x + index, gameObject.transform.position.y, gameObject.transform.position.z);
        StartCoroutine(LerpPosition(positionToMoveTo, lerpDuration));
        currentRoadIndex++;
    }

    //The player goes to the new road / Right
    void SubstractActorLocationX(int index)
    {
        positionToMoveTo = new Vector3(gameObject.transform.position.x - index, gameObject.transform.position.y, gameObject.transform.position.z);
        StartCoroutine(LerpPosition(positionToMoveTo, lerpDuration));
        currentRoadIndex--;
    }

    

}
