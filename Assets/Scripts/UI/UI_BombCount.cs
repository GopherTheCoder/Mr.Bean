using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BombCount : MonoBehaviour
{
    public GameObject bombImage;
    public Color active, inactive;

    private Image[] bombImages;
    private PlayerCrate playerCrate;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        playerCrate = GameObject.Find("Hero").GetComponent<PlayerCrate>();
        for (int i = 0; i < playerCrate.maxBombCount; i++)
            Instantiate(bombImage, transform);
        bombImages = GetComponentsInChildren<Image>();
    }

    public void BombCountUpdate(int newCount)
    {
        if (newCount > count)
            bombImages[count].color= active;
        else
            bombImages[newCount].color = inactive;
        count = newCount;
    }
}
