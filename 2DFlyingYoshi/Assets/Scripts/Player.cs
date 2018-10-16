using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rigid;
    Animator anim;
  
    float speed = 5f;
	void Start () {

		anim = GetComponent<Animator>();
		rigid = GetComponent<Rigidbody2D>();

	}

    private void Update()
    {
		float x = Input.GetAxisRaw("Horizontal");
		Vector2 direction = new Vector2(x, 0);
		direction.Normalize();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetTrigger("Left");
            Move(direction);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey((KeyCode.RightArrow)))
        {
            anim.SetTrigger("Right");
            Move(direction);
        }

    }
    void Move(Vector2 direction)
	{
		//랜더링 파이프라인 (보이는 좌표를 게임상 좌표로) - 카메라 밖으로 못나가게 한다.
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		Vector2 pos = transform.position;
		pos += direction * Time.deltaTime * speed;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);

		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(pos.x, -200));

		transform.position = pos;
        anim.SetTrigger("Stop");
    }

    //box collider에 istrigger 사용했을 때 사용
	private void OnCollisionEnter2D(Collision2D collision)
	{
        string layername = LayerMask.LayerToName(collision.gameObject.layer);
        if (layername == "Gameover")
        {
            this.gameObject.SetActive(false);
            GameManager.current.GameOver();
        }
        else if (layername =="lightning")
        {
            AudioManager.instance.Shock();
            GameManager.current.SubHp(2);
        }

    }


}
