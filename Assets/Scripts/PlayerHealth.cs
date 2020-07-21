using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float hitInterval = 0.35f;
    public float pushForceX = 100;
    public float pushForceY = 100;
    public float damage = 10;
    public AudioClip[] ouchAudios;
    public GameObject UI_Result;

    private SpriteRenderer healthBar;
    private float lastHitTime;
    private Vector3 healthScale;
    private Rigidbody2D hero;
    private PlayerControl playerControl;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("Health").GetComponent<SpriteRenderer>();
        hero = GetComponent<Rigidbody2D>();
        healthScale = healthBar.transform.localScale;
        playerControl = GetComponent<PlayerControl>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Time.time - lastHitTime > hitInterval && health > 0)
        {
            lastHitTime = Time.time;

            Push(collision.transform.position);
            PushBack(collision.gameObject);

            TakeDamage(); Ouch();
            if (health <= 0) { health = 0; UpdateHealthBar(); Die(); return; }
            UpdateHealthBar();
        }
    }

    private void Ouch() => audioSource.PlayOneShot(ouchAudios[Random.Range(0, ouchAudios.Length)]);

    private void PushBack(GameObject gameObject) =>
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(
        pushForceX * (gameObject.transform.position.x - transform.position.x),
        pushForceY * (gameObject.transform.position.y - transform.position.y)));

    public void UpdateHealthBar()
    {
        health = Mathf.Clamp(health, 0, 100);
        healthBar.material.color = Color.Lerp(Color.red, Color.green, health / 100);
        healthBar.transform.localScale = new Vector3(healthScale.x * health / 100, healthScale.y);
    }

    private void Push(Vector3 enemy) => hero.AddForce(new Vector2(
        pushForceX * (transform.position.x - enemy.x),
        pushForceY * (transform.position.y - enemy.y)));

    private void Die()
    {
        playerControl.enabled = false;
        gameObject.GetComponentInChildren<Fire>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("Die");
        hero.Sleep();
        hero.AddForce(Vector2.up * playerControl.jumpForce);
    }

    private void TakeDamage() => health -= damage;

    private void StartFalling() => gameObject.GetComponent<Collider2D>().isTrigger = true;

    private void OnDestroy()
    {
        GameObject.Find("Pause Menu").SetActive(false);
        if (UI_Result)
            UI_Result.SetActive(true);
        Time.timeScale = 0;
    }
}
