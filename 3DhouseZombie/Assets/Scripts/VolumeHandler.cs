using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeHandler : MonoBehaviour {

	void Start ()
    {
        GameObject FxSlider = GameObject.Find("EffectSlider");
        if(FxSlider != null)
        {
            FxSlider.GetComponent<UnityEngine.UI.Slider>().onValueChanged.AddListener(SetVolume);
            SetVolume(FxSlider.GetComponent<UnityEngine.UI.Slider>().value);
        }
    //    testfct mytest = SetVolume;
    //    mytest(10);
    }
  //  delegate void testfct(float volume);

    void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
    }
	void OnDestroy()
    {
        GameObject FxSlider = GameObject.Find("EffectSlider");
        if (FxSlider != null)
        {
            FxSlider.GetComponent<UnityEngine.UI.Slider>().onValueChanged.RemoveListener(SetVolume);
        }
    }
}
