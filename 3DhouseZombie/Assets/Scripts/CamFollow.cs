using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public Transform target;

    Vector3 offset;
	void Start ()
    {
        offset = transform.position - target.position;
	}

    //public UnityEngine.UI.Image BlackImage;
	void Update ()
    {
        //BlackImage.color = Color.Lerp(BlackImage.color, Color.clear,Time.deltaTime);

        Vector3 Targetpos =  target.position + offset;

        transform.position = Vector3.Slerp(transform.position,
                                          Targetpos, Time.deltaTime * 5f);


        //Vector3 Direction = Targetpos - transform.position;
        //Direction.Normalize();
        //transform.position += Direction * Time.deltaTime * 3f;
    }
}
