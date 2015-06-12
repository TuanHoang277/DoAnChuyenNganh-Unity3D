using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton<GameManager> {

	public string sMainDACN;
	public string sNemXien;
	public string sNemNgang;
	public string sFricTion;
	public string sMotion;
	public string sConLacDon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSceneNemXien() 
	{
		Application.LoadLevel (sNemXien);
	}

	public void LoadSceneNemNgang() 
	{
		Application.LoadLevel (sNemNgang);
	}

	public void LoadSceneFriction() 
	{
		Application.LoadLevel (sFricTion);
	}

	public void LoadSceneMotion() 
	{
		Application.LoadLevel (sMotion);
	}

	public void LoadSceneConLacDon() 
	{
		Application.LoadLevel (sConLacDon);
	}

	[ContextMenu("LoadSceneDACN")]
	public void LoadSceneDACN() 
	{
		Application.LoadLevel ("DACN_Main");
	}
}
