using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string layername = LayerMask.LayerToName(collision.gameObject.layer);
        if (layername == "Player")
        {
            GameManager.current.AddHp();
            AudioManager.instance.Pickup();
            this.gameObject.SetActive(false);
        }
        else
            return;

    }
}
