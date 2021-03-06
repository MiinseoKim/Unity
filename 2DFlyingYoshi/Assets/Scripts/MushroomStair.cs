﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomStair : MonoBehaviour
{

	float speed = 3f;
	//덜덜거림 막기(더 빠른 물리연산으로인한?)
	private void FixedUpdate()
	{
		Vector2 pos = transform.position;
		pos.y += Time.fixedDeltaTime * speed;
		transform.position = pos;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		string layername = LayerMask.LayerToName(collision.gameObject.layer);
		if (layername != "Player")
			return;
		GameManager.current.AddScore();
	}


}
