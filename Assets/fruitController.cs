using UnityEngine;
using System.Collections;

public class fruitController : MonoBehaviour {

    public float force;
    public float angle;
    public Rigidbody mRigidbody;
	// Use this for initialization
	void Start () {

        test = false;
        mRigidbody = GetComponent<Rigidbody>();
        ////rigidbody.AddForce(Vector3.up * 10);
        //Vector3 forceC = new Vector3(force * Mathf.Cos(angle * Mathf.Deg2Rad)
        //        , force * Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        //Debug.Log(forceC);
        //gameObject.GetComponent<Rigidbody>().AddForce(forceC);
	}

    public Vector3 startPos ;
    public void ThrowFruit()
    {
        mRigidbody.velocity =Vector3.zero;
        transform.position = startPos;
        transform.rotation = Quaternion.identity;

        Vector3 forceC = new Vector3(force * Mathf.Cos(angle * Mathf.Deg2Rad)
                , force * Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        Debug.Log(forceC);
        gameObject.GetComponent<Rigidbody>().AddForce(forceC);
	}
    

	// Update is called once per frame
	void Update () {

        //test = Input.GetButtonDown("Jump");
        //if (test)
        //{
        //    test = false;
        //    ThrowFruit();
        //}

        //if (Input.GetButtonDown("Cancel"))
        //{
        //    Debug.Log("Quit");
        //    Application.Quit();
        //}
	}
    public bool test = false;
}
