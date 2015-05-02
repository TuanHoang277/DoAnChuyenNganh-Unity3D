using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public TextMesh txtTimer;
    private float timeCur;
	// Use this for initialization
	void Start () {
        timeCur = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timeCur += Time.deltaTime;
	}
}
