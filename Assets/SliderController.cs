using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text txtValue;
    public Slider slider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down Slider");
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up Slider");
        slider.value = 0;
        txtValue.text = slider.value.ToString();

        //throw new System.NotImplementedException();
    }

    public void OnValueChange() 
    {
        txtValue.text = slider.value.ToString();
    }
}
