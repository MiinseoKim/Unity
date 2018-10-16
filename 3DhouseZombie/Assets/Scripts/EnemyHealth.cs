using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    int currentHp;
    public int MaxHp = 100;
    ParticleSystem Hitparticle;

    public AudioClip DeadthClip;
    AudioSource audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        Hitparticle = GetComponentInChildren<ParticleSystem>();
        currentHp = MaxHp;
    }

    bool IsSinking = false;
    void StartSinking()
    {
        IsSinking = true;
    }
    public void TakeDamage(int damage, Vector3 hitpoint)
    {
        Hitparticle.transform.position = hitpoint;
        Hitparticle.Play();
        currentHp -= damage;
        if (currentHp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Dead");
            //GetComponent<EnemyMovement>().enabled = false;
            Destroy(GetComponent<EnemyMovement>());
            Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponentInChildren<EnemyAttack>());

            audio.clip = DeadthClip;
        }
        audio.Play();
    }

    void Update () {
        if(IsSinking)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.3f);

            if (transform.position.y < -2f)
                Destroy(gameObject);
        }

    }
}
