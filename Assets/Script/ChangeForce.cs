using UnityEngine;
using System.Collections;

public class ChangeForce : MonoBehaviour {

	// Use this for initialization
    public float M_Force = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<TextMesh>().text = M_Force.ToString();
	}

    public void Change_Force(float  force)
    {
        M_Force = force;
    }
}
