using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public EnemySpawn spawn;
    public float wanderSpeed = 10f;
    public float wanderWalkTime = 3.0f;
    public float wanderStopTime = 2.0f;
    public float turnSpeed = 10f;
    public float aggroSpeed = 2f;
    public Color aggroColor = new Color(1, 0, 0);

    
    enum Mode
    {
        wanderWalk,
        wanderStop,
        aggro
    }

    private Mode myMode;
    private Rigidbody2D myBody;
    private void Start()
    {
        myMode = Mode.wanderWalk;
        myBody = GetComponent<Rigidbody2D>();
        timeInMode = wanderWalkTime;
        myBody.rotation = Random.Range(0, 360);
    }

    private float timeInMode;
    void FixedUpdate ()
    {
        float updateTime = Time.fixedDeltaTime;
        Debug.Log("myMode: " + myMode);
        
        switch (myMode)
        {
            case Mode.wanderWalk:
                myBody.velocity = (Vector2)transform.right * wanderSpeed;
                myBody.angularVelocity = 0;
                timeInMode -= updateTime;
                if(timeInMode <= 0)
                {
                    myMode = Mode.wanderStop;
                    timeInMode = wanderStopTime;
                }
                break;
            case Mode.wanderStop:
                myBody.velocity = Vector2.zero;
                timeInMode -= updateTime;
                if (timeInMode <= 0)
                {
                    myMode = Mode.wanderWalk;
                    timeInMode = wanderWalkTime;
                    myBody.rotation = Random.Range(0,360);
                }
                break;
            case Mode.aggro:
                break;
        }


    }
}
