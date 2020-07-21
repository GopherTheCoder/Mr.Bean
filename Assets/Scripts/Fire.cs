using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rocket;
    public int heatUp, heatDown;
    public float cooldownInterval;

    private PlayerControl playerControl;
    private Slider overheatSlider;
    private Image heatImage;
    private int heatMax;
    private int heat;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = transform.parent.GetComponent<PlayerControl>();
        overheatSlider = GameObject.Find("OverheatSlider").GetComponent<Slider>();
        heatImage = overheatSlider.transform.Find("Fill Area/Fill").GetComponent<Image>();
        heatMax = (int)overheatSlider.maxValue;
        InvokeRepeating("cooldown", 0, cooldownInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && heat <= heatMax - heatUp)
        {
            if (playerControl.faceRight)
            {
                Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet.velocity = new Vector2(speed, 0);
            }
            else
            {
                Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                bullet.velocity = new Vector2(-speed, 0);
            }
            HeatUp();
        }
    }

    private void HeatUp()
    {
        heat += heatUp;
        HeatUpdate();
    }

    private void cooldown()
    {
        if (heat > 0)
        {
            heat -= heatDown;
            HeatUpdate();
        }
    }

    private void HeatUpdate()
    {
        overheatSlider.value = heat;
        heatImage.color = Color.Lerp(Color.green, Color.red, 1f * heat / heatMax);
    }
}
