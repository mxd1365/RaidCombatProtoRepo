using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject cameraObject;
    public float camFollowDistance = 5;
    public float moveSpeed = 10;

    void Start () {
	}

    Vector2 camTargetPos;
	void LateUpdate () {

        float updateTime = Time.deltaTime;

        float xDist = transform.position.x - cameraObject.transform.position.x;
        float yDist = transform.position.y - cameraObject.transform.position.y;

        Vector3 newCamPos = cameraObject.transform.position;
        if (Mathf.Abs(xDist) > camFollowDistance || Mathf.Abs(yDist) > camFollowDistance)
        {
            Vector3 moveDir = new Vector3(transform.position.x, transform.position.y, newCamPos.z) - newCamPos;
            moveDir.Normalize();
            newCamPos += (moveDir * moveSpeed * updateTime);
        }
   

        cameraObject.transform.position = newCamPos;
        
        Debug.Log("camTargetPos: " + newCamPos);
	}
}
