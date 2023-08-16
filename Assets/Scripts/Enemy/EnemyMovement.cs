using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    // https://www.youtube.com/watch?v=AiZ4z4qKy44

    [SerializeField] private Animator animator;

    public void MoveUp() {
        StartCoroutine(Move(Vector3.up));
        animator.SetTrigger("Up");
    }

    public void MoveDown() {
        StartCoroutine(Move(Vector3.down));
        animator.SetTrigger("Down");
    }   

    public void MoveLeft() {
        StartCoroutine(Move(Vector3.left));
        animator.SetTrigger("Left");
    }

    public void MoveRight() {
        StartCoroutine(Move(Vector3.right));
        animator.SetTrigger("Right");
    }

    private IEnumerator Move(Vector3 dir) {

        float elapsedTime = 0;
        float timeToMove = 0.8f;
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
