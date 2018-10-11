using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float camFollowDistance = 5;
    public float moveSpeed = 10;
    public float lerpSpeed = .125f;

    Vector2 camTargetPos;
	void LateUpdate () {

        float updateTime = Time.deltaTime;

        float xDist = transform.position.x - Camera.main.transform.position.x;
        float yDist = transform.position.y - Camera.main.transform.position.y;

        Vector2 newCamPos = Camera.main.transform.position;
        if (Mathf.Abs(xDist) > camFollowDistance)
        {
            if (xDist > 0)
            {
                newCamPos.x = transform.position.x + camFollowDistance;
            }
            else
            {
                newCamPos.x = transform.position.x - camFollowDistance;
            }
        }

        if (Mathf.Abs(yDist) > camFollowDistance)
        {
            if (yDist > 0)
            {
                newCamPos.y = transform.position.y + camFollowDistance;
            }
            else
            {
                newCamPos.y = transform.position.y - camFollowDistance;
            }
        }

        Vector2 finalCamPosition = Vector2.Lerp((Vector2)Camera.main.transform.position, newCamPos, lerpSpeed * updateTime);

        Camera.main.transform.position = (new Vector3(finalCamPosition.x, finalCamPosition.y,Camera.main.transform.position.z));
        
        Debug.Log("camTargetPos: " + newCamPos);
	}
}
