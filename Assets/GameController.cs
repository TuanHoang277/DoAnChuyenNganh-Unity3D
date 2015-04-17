using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject TrajectoryPointPrefeb;
    //public GameObject BallPrefb;

    public Vector3 startPosBall;
    //public Rigidbody ballRigidboby;

    public GameObject ball;
    
    private bool isPressed, isBallThrown;
    public float power = 25;
    public int numOfTrajectoryPoints = 30;
    private List<GameObject> trajectoryPoints;

	// Use this for initialization
	void Start () {
        trajectoryPoints = new List<GameObject>();
        isPressed = isBallThrown = false;
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            GameObject dot = (GameObject)Instantiate(TrajectoryPointPrefeb);
            dot.GetComponent<MeshRenderer>().enabled = false;
            //dot.renderer.enabled = false;
            trajectoryPoints.Insert(i, dot);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isBallThrown)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            ResetBall();
            //if (!ball)
                
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            if (!isBallThrown)
            {
                throwBall();
            }
        }
        if (isPressed)
        {
            //luc
            Vector3 vel = GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
            //transform.eulerAngles = new Vector3(0, 0, angle);
            //mass la khoi luong
            setTrajectoryPoints(startPosBall, vel / ball.GetComponent<Rigidbody>().mass);
        }
	}

    void ResetBall() 
    {
        //Debug.Log("Reset ball pos = " + transform.)
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.position = startPosBall;
        ball.transform.rotation = Quaternion.identity;
    }

    //---------------------------------------	
    private void throwBall()
    {
        ball.SetActive(true);
        ball.GetComponent<Rigidbody>().useGravity = true;
        Vector2 force = GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log("force = " + force);
        ball.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        isBallThrown = true;
    }
    //---------------------------------------	
    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y)) * power;//*ball.rigidbody.mass;
    }

    void setTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        float angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
        float fTime = 0;

        fTime += 0.1f;
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
            float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
            Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, 0);
            trajectoryPoints[i].transform.position = pos;
            trajectoryPoints[i].GetComponent<MeshRenderer>().enabled = true;
            trajectoryPoints[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }
    }
}
