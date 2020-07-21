using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public float speed;
    public GameObject score;
    public AudioClip[] deathAudios;

    private new Rigidbody2D rigidbody;
    private AudioSource audioSource;
    private bool die = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(transform.localScale.x * speed, rigidbody.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
            flip();
    }

    private void flip()
    {
        Vector3 vectorT = transform.localScale;
        vectorT.x *= -1;
        transform.localScale = vectorT;
    }

    override public void Hurt()
    {
        if (!die)
        {
            die = true;
            GetComponent<Animator>().enabled = false;
            SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < 4; i++)
                renderers[i].enabled = false;
            renderers[4].enabled = true;

            audioSource.PlayOneShot(deathAudios[Random.Range(0, deathAudios.Length)]);
            Instantiate(score, transform.position, Quaternion.identity);
            GameObject.Find("ScoreNumber").GetComponent<UI_Score>().AddScore(100);
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
