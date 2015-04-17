using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameController_NemNgang : MonoBehaviour
{

    public GameObject TrajectoryPointPrefeb;
    //public GameObject BallPrefb;
    public float gravity = 10.0f;
    public float angle;

    public float vellocity;

    public Vector3 startPosBall;
    //public Rigidbody ballRigidboby;

    public GameObject ball;

    public Text txtButton;

    private bool isPressed, isBallThrown;
    public float power = 25;
    public int numOfTrajectoryPoints = 30;
    private List<GameObject> trajectoryPoints;

    // Use this for initialization
    void Start()
    {

        start = false;

        ball.gameObject.transform.position = startPosBall;
        trajectoryPoints = new List<GameObject>();
        isPressed = isBallThrown = false;
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            GameObject dot = (GameObject)Instantiate(TrajectoryPointPrefeb);
            dot.GetComponent<MeshRenderer>().enabled = false;
            //dot.renderer.enabled = false;
            trajectoryPoints.Insert(i, dot);
        }

        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isBallThrown)
        //    return;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    isPressed = true;
        //    ResetBall();
        //    //if (!ball)

        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    isPressed = false;
        //    if (!isBallThrown)
        //    {
        //        throwBall();
        //    }
        //}
        //if (isPressed)
        //{
        //    //luc
        //    Vector3 vel = GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //    float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        //    //transform.eulerAngles = new Vector3(0, 0, angle);
        //    //mass la khoi luong
        //    //setTrajectoryPoints(startPosBall, vel / ball.GetComponent<Rigidbody>().mass);
        //}

        if (start)
        {
            if (time_current <= time_Max && time_current + Time.deltaTime >= time_Max)
            {
                Pause();
                ShowInFoWhenHeightMax(time_Max, widthMax);
            }
            else
            {
                HideInfoHeightMax();
            }
            time_current += Time.deltaTime;

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

    private Vector2 veloc_save;
    private bool isPause;
    public void Pause()
    {
        veloc_save = ball.GetComponent<Rigidbody>().velocity;
        isPause = true;
        ball.GetComponent<Rigidbody>().velocity = Vector2.zero;
        ball.GetComponent<Rigidbody>().useGravity = false;
        txtButton.text = "Resune";
        start = false;
    }

    public void Resume()
    {
        ball.GetComponent<Rigidbody>().velocity = veloc_save;
        isPause = false;
        ball.GetComponent<Rigidbody>().useGravity = true;
        veloc_save = Vector2.zero;
        txtButton.text = "Pause";
        start = true;
    }

    public void OnClick_ButtonPause()
    {
        if (isPause)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private float time_Max;
    private float widthMax;
    private bool start;
    private float time_current;

    //---------------------------------------	
    [ContextMenu("throwBall")]
    public void throwBall()
    {
        ResetBall();
        isPause = false;
        ball.SetActive(true);
        ball.GetComponent<Rigidbody>().useGravity = true;
        float vx = Mathf.Cos(angle * Mathf.Deg2Rad) * vellocity;
        float vy = Mathf.Sin(angle * Mathf.Deg2Rad) * vellocity;
        Vector2 v = new Vector2(vx, vy);
        //GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        ball.GetComponent<Rigidbody>().velocity = v;
        //Debug.Log("force = " + force);
        //ball.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        isBallThrown = true;

        time_current = 0;
        widthMax = vellocity * Mathf.Sqrt((2 * startPosBall.y) / gravity);
        time_Max = Mathf.Sqrt((2 * startPosBall.y) / gravity);

        start = true;
    }

    public TextMesh txtTimeMax;
    public TextMesh txtWidthMax;
    public GameObject congThucWidthMax;

    public void ShowInFoWhenHeightMax(float timeMax, float widthMax)
    {
        congThucWidthMax.SetActive(true);
        txtTimeMax.text = String.Format("Time Max = {0} (s)", timeMax);
        txtWidthMax.text = String.Format("Width Max = {0} (m)", widthMax);
    }

    public void HideInfoHeightMax()
    {
        congThucWidthMax.SetActive(false);
    }
    //---------------------------------------	
    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        //Vector2 force = new Vector2(Mathf.Cos(alpha) * power, Mathf.Sin(alpha) * power);
        //return force;
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

    public void ChangePower(float Power)
    {
        power = Power;
    }

    public void ChangeVeloc(float veloc)
    {
        vellocity = veloc;
    }

    public void ChangeAngle(float Angle)
    {
        angle = Angle;
    }

    public void ChangeStartPos(float posY)
    {
        startPosBall.y = posY;
        ball.gameObject.transform.position = startPosBall;
    }
}
