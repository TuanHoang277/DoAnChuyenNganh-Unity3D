using UnityEngine;
using System.Collections;

public class FrictionController : MonoBehaviour {

    public TextMesh txtTimer;
    private float timeCur;
    private GameController game;

    // Use this for initialization
    void Start()
    {
        timeCur = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeCur += Time.deltaTime;
        txtTimer.text = System.String.Format("Time = {0}", timeCur);
    }
}
