using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip pickup; 
    public AudioClip shock; 
    public AudioClip gameover; //재생할 소리를 변수로 담습니다.
	AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
	public static AudioManager instance;  //자기자신을 변수로 담습니다.다른 스크립트에서 이스크립트에있는 함수를 호출할때
	void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
	{
		if (AudioManager.instance == null) //incetance가 비어있는지 검사합니다.
		{
			AudioManager.instance = this; //자기자신을 담습니다.
		}
	}
	void Start()
	{
		myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
	}
	public void Pickup()
	{
		myAudio.PlayOneShot(pickup);
	}
	public void Shock()
	{
		myAudio.PlayOneShot(shock); 
	}
	public void Gameover()
	{
		myAudio.PlayOneShot(gameover);
	}
}
