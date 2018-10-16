using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject titleObject;
    public GameObject overObject;

    public GameObject player;
    public GameObject spawner;

    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text hpText;
   
    int currentScore = 0;
    int hp = 5;

    //public UnityEngine.UI.Text BestScoreText;
    //int bestScore = 0;

    const string BestScoreKey = "Best Score";
    public static GameManager current;

	
	void Update () {
        if (!IsPlaying() && Input.anyKeyDown)
        {
            GameStart();
        }
    }

    //start와 같은기능, start보다 먼저 실행
    private void Awake()
    {
        if (current == null)
            current = this;
        else
           
            Debug.LogError("Not Single GameManager");
    }

    public void AddScore()
    {
        currentScore ++;
        scoreText.text = "SCORE "+currentScore.ToString();
    }
    public void SubHp(int a)
    {
        hp -= a;
		if (hp <= 0)
		{
            hp = 0;
			GameOver();
		}
        hpText.text = "HP " + hp.ToString();
	}
    public void AddHp()
    {
        ++hp;
		if (hp >= 5)
		{
			hp = 5;
		}
        hpText.text = "HP " + hp.ToString();
    }

    public bool IsPlaying()
    {
        //true 면 게임중, false면 안하는중
        return !overObject.activeSelf;
    }

    void GameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        scoreText.text = "0";
        hpText.text = "0";
        currentScore = 0;
        hp = 5;
  

        player.SetActive(true);
        spawner.SetActive(true);
    }
    public void GameOver()
    {
       // titleObject.SetActive(true);
        AudioManager.instance.Gameover();
        overObject.SetActive(true);
        spawner.SetActive(false);

    }
}
