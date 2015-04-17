using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

    public GameObject Text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    private bool flat = true;
	void Update () {
        //if (flat)
        //{
        //    this.
        //}
        //else
        //{
        //    this.GetComponent<TextMesh>().text = "Resume";
        //}
	}

    public void ChangeFlat()
    {
        if (flat)
        {
            flat = false;
        }
        else
        {
            flat = true;
        }
    }
}
