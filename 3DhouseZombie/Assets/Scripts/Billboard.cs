using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public Transform Cam;

	void Update () {
        transform.rotation = Cam.rotation;
    }
}
