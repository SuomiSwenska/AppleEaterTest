using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    protected Gameplay _gameplay;
    public Action<Vector3> OnGetNewMovingPosition;

    protected void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
    }

    protected virtual void Update()
    {

#if ANDROID
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
#else
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

            OnGetNewMovingPosition?.Invoke(worldPosition);
        }
#endif
    }

    public void StartButtonDown()
    {
        _gameplay.OnStartButtonDown?.Invoke();
    }
}
