using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public UnityEngine.UI.Image HitImage;
    public UnityEngine.UI.Slider HpSlider;

    public Color FlashColor;
    int currentHP;
    int MaxHP = 100;

    public AudioClip DeathClip;
    AudioSource audio;
    void Awake ()
    {
        audio = GetComponent<AudioSource>();
        HpSlider.value = HpSlider.maxValue = currentHP = MaxHP;
    }
	
    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //Application.LoadLevel(0);
    }
    public void TakeDamage(int damage)
    {
        if (currentHP <= 0)
            return;

        HitImage.color = FlashColor;
        currentHP -= damage;
        HpSlider.value = currentHP;
        if(currentHP <= 0 )
        {
            GetComponent<Animator>().SetTrigger("Die");
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponentInChildren<PlayerShooting>());
            audio.clip = DeathClip;
        }
        audio.Play();
    }
	// Update is called once per frame
	void Update ()
    {
        HitImage.color = Color.Lerp(HitImage.color, Color.clear, Time.deltaTime * 5f);
    }
}
