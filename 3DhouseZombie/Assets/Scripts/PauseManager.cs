using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    Canvas canvase;
	void Start () {
        canvase = GetComponent<Canvas>();
    }
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
    public void Pause()
    {
        canvase.enabled = !canvase.enabled;
        if (canvase.enabled)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void Quit ()
    {
        #if UNITY_EDITOR
           UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
