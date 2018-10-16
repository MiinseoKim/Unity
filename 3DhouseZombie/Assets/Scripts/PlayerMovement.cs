using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    int floorMask;
	void Awake () {
        anim = GetComponent<Animator>();
        floorMask = LayerMask.GetMask("Floor");
    }
	void FixedUpdate ()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Animating(h, v);
        Turning();
    }
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //선이랑 충돌한 물체정보를 받아올 객체
        RaycastHit floorHit;
        if(Physics.Raycast(camRay,out floorHit,Mathf.Infinity, floorMask))
        {
            //충돌하면 여기로 들어온다.

            Vector3 Direction = floorHit.point - transform.position;
            Quaternion newRotation= Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                                 newRotation, Time.deltaTime * 10f);
            

            //transform.LookAt(floorHit.point);

        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("Move", walking);
    }
    float speed = 6f;
    void Move(float h,float v)
    {
        Vector3 vDirection = new Vector3(h, 0f, v);
        vDirection.Normalize();
        transform.position += vDirection * Time.fixedDeltaTime * speed;
    }
}
