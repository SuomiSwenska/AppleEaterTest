using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;
    [SerializeField] private float movementSpeed;

    private Vector3 nextPosition;

    private void Update()
    {
        LerpToCharacterPosition();
    }

    private void LerpToCharacterPosition()
    {
        nextPosition = new Vector3(characterTransform.position.x, transform.position.y, characterTransform.position.z);
        transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * movementSpeed);
    }
}
