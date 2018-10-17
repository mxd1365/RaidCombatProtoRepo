using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float lerpSpeed = 1f;
    public float borderSize = 1f;

	void LateUpdate () {

        float updateTime = Time.deltaTime;

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        vertExtent -= borderSize;
        horzExtent -= borderSize;

        float xDist = transform.position.x - Camera.main.transform.position.x;
        float yDist = transform.position.y - Camera.main.transform.position.y;

        Vector2 newCamPos = Camera.main.transform.position;
        if (Mathf.Abs(xDist) > horzExtent)
        {
            if(xDist > 0)
                newCamPos.x += xDist - horzExtent;
            else
                newCamPos.x += xDist + horzExtent;
        }

        if (Mathf.Abs(yDist) > vertExtent)
        {
            if (yDist > 0)
                newCamPos.y += yDist - vertExtent;
            else
                newCamPos.y += yDist + vertExtent;
        }



        Camera.main.transform.position = (new Vector3(newCamPos.x, newCamPos.y,Camera.main.transform.position.z));
        
       // Debug.Log("camTargetPos: " + newCamPos);
	}
}
