using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSpawner : MonoBehaviour {

    public GameObject stairPrefab;
    public GameObject firePrefab;
    public GameObject eggPrefab;
    const int stairPoolSize = 6;
    GameObject[] stairs;
    int[] stairCount = new int[6] { 0, 0, 0, 1, 1, 2 };
    int currentStair = 0;
    int temp;
    void Start()
    {
		//기둥의 주소를 담을수있는 배열을 5개 생성
		stairs = new GameObject[stairPoolSize];		
        Shuffle(5,stairCount);
		for (int i = 0; i < stairPoolSize; ++i)
		{
			//생성한 기둥을 배열에 차례대로 넣는다.  
			stairs[i] = IndexToObject(stairCount[i]); //기둥 생성
		}

		//인자 함수이름,시작시간,반복시간
		InvokeRepeating("Spawn", 0, 1);
	}


	void Spawn()
	{
		Vector3 pos = transform.position;
        pos.x = Random.Range(-3f, 3f);
        stairs[currentStair].transform.position = pos;
        ++currentStair;
        if (currentStair >= stairPoolSize)
        {
            int ran = Random.Range(0, 3);
            currentStair = ran;
           			
        }
	}

    void Shuffle(int range, int[] a)
    {		
		for (int i = 0; i < 20; i++)
		{
			int rand = Random.Range(0, range);
			int dest = Random.Range(0, range);
			temp = a[rand];
			a[rand] = a[dest];
			a[dest] = temp;
		}
		
	}

    GameObject IndexToObject(int Index)
	{
		switch (Index)
		{
			case 0:
				return Instantiate(stairPrefab);

			case 1:
				return Instantiate(firePrefab);

			case 2:
				return Instantiate(eggPrefab);

		}
		return null;
	}
}
