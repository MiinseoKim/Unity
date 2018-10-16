using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    Light gunlight;
    ParticleSystem gunParticle;
    LineRenderer gunline;
    AudioSource gunaudio;

    int shootableMask;
    void Awake ()
    {
        shootableMask = LayerMask.GetMask("Shootable");

        gunaudio = GetComponent<AudioSource>();
        gunlight = GetComponent<Light>();
        gunParticle = GetComponent<ParticleSystem>();
        gunline = GetComponent<LineRenderer>();
    }
    float timer = 0;
    const float timeBetweenBullets = 0.15f;

    void Update ()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            timer = 0;
            Shoot();
        }
        if(timer >= timeBetweenBullets * 0.2f)
        {
            gunlight.enabled = false;
            gunline.enabled = false;
        }
	}
    void Shoot()
    {
        gunaudio.Play();

        Ray ShootRay = new Ray();
        ShootRay.origin = transform.position; //시작점
        ShootRay.direction = transform.forward; //방향

        gunline.enabled = true;
        gunline.SetPosition(0, transform.position);
        RaycastHit ShootHit; //맞은 친구가 누군지
        if(Physics.Raycast(ShootRay,out ShootHit,100f,shootableMask ))
        {
            EnemyHealth health = ShootHit.collider.GetComponent<EnemyHealth>();
            if(health != null)
            {
                health.TakeDamage(10, ShootHit.point);
            }

            //충돌시 여기 들어온다.
            gunline.SetPosition(1, ShootHit.point);
        }
        else
            gunline.SetPosition(1, ShootRay.origin + (ShootRay.direction * 100f));

        gunlight.enabled = true;
        gunParticle.Play();
    }
}
