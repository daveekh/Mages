using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // https://www.youtube.com/watch?v=AiZ4z4qKy44

    public void MoveUp() {
        StartCoroutine(Move(Vector3.up));
    }

    public void MoveDown() {
        StartCoroutine(Move(Vector3.down));
    }   

    public void MoveLeft() {
        StartCoroutine(Move(Vector3.left));
    }

    public void MoveRight() {
        StartCoroutine(Move(Vector3.right));
    }

    private IEnumerator Move(Vector3 dir) {
        float elapsedTime = 0;
        float timeToMove = 0.3f;
        Vector3 origPos = transform.position;
        Vector3 targetPos = transform.position + dir;

        while(elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }

}
