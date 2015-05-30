using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController_Motion : MonoBehaviour {

    public Rigidbody rigidMoveObj;

    public PhysicMaterial pmMoveObj;

    public PhysicMaterial pmStaticObj;

    public float maxForce;
    float force;

    public Slider sliderForce;
    public Slider sliderMass;
    public Slider sliderFriction;

    public Text txtValueForce;
    public Text txtValueMass;
    public Text txtValuaFriction;


	// Use this for initialization
	void Start () {
        //rigidMoveObj.AddForce(transform.forward * force);
        sliderForce.value = 0;

        txtValueMass.text = sliderMass.value.ToString();
        txtValueForce.text = force.ToString();
        txtValuaFriction.text = sliderFriction.value.ToString();

        pmStaticObj.staticFriction = sliderFriction.value;
        rigidMoveObj.mass = sliderMass.value;
        force = sliderForce.value;
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}

    void FixedUpdate() 
    {
        Vector3 addForce = new Vector3(force, 0, 0);
        rigidMoveObj.AddForce(addForce, ForceMode.Impulse);
        
    }

    public void OnChangeForce() 
    {
        force = sliderForce.value;
        txtValueForce.text = force.ToString();
        //changeValuaSlider = true;
        //Selectable select = (Selectable)sliderForce;
        //sliderForce.OnPointerDown(new UnityEngine.EventSystems.PointerEventData());
        //select.
        //sliderForce.OnPointerDown(
        //pmMoveObj.dynamicFriction
    }

    public void OnChangeFriction() 
    {
        txtValuaFriction.text = sliderFriction.value.ToString();
        pmStaticObj.staticFriction = sliderFriction.value;
        pmStaticObj.dynamicFriction = sliderFriction.value;
    }

    public void OnChangeMass() 
    {
        txtValueMass.text = sliderMass.value.ToString();
        rigidMoveObj.mass = sliderMass.value;
    }
}
