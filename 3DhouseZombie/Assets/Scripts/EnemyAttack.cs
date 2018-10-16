using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int damage = 10;

    PlayerHealth Health;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Health = other.GetComponent<PlayerHealth>();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Health = null;
    }
    float timer = 0;
	void Update ()
    {
        timer += Time.deltaTime;
        if(Health != null && timer >= 1f)
        {
            timer = 0;
            Health.TakeDamage(damage);
        }
    }
}
