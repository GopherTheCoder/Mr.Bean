using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrate : MonoBehaviour
{
    public int maxBombCount;
    public GameObject bomb;
    public float healthAdd;
    public AudioClip healthPickUp, ammoPickUp;

    private int bombCount;
    private PlayerHealth playerHealth;
    private CrateSpawner crateSpawner;
    private Transform layBombPos;
    private UI_BombCount ui_BombCount;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        crateSpawner = GameObject.Find("CrateSpawner").GetComponent<CrateSpawner>();
        layBombPos = transform.Find("LayBomb").transform;
        ui_BombCount = GameObject.Find("BombCount").GetComponent<UI_BombCount>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && bombCount > 0)
        {
            Instantiate(bomb, layBombPos.position, Quaternion.identity);
            bombCount--;
            ui_BombCount.BombCountUpdate(bombCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthCrate"))
        {
            Destroy(collision.transform.parent.gameObject);
            playerHealth.health += healthAdd;
            playerHealth.UpdateHealthBar();
            crateSpawner.crateExist = false;
            StartCoroutine(crateSpawner.SpawnCrate());
            audioSource.PlayOneShot(healthPickUp);
        }
        else if (collision.CompareTag("AmmoCrate"))
        {
            Destroy(collision.transform.parent.gameObject);
            if (bombCount < maxBombCount)
            {
                bombCount++;
                ui_BombCount.BombCountUpdate(bombCount);
            }
            crateSpawner.crateExist = false;
            StartCoroutine(crateSpawner.SpawnCrate());
            audioSource.PlayOneShot(ammoPickUp);
        }
    }
}
