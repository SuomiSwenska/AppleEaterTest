using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Gameplay _gameplay;
    public Action<Vector3> OnGetNewMovingPosition;

    private void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = touch.position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 10f));

                OnGetNewMovingPosition?.Invoke(worldPosition);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

            OnGetNewMovingPosition?.Invoke(worldPosition);
        }
    }

    public void StartButtonDown()
    {
        _gameplay.OnStartButtonDown?.Invoke();
    }
}
