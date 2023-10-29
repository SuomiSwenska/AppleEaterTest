using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerAndroid : InputController
{
    protected override void Update()
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
    }
}
