using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float scaleCamera2BGX;
    public float scaleBGsX;
    public float scaleCamera2BGY;
    public float scaleBGsY;
    public Transform[] transformBackGrounds;

    private Transform transformCamera;
    private Vector3 preCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        //transformCamera = GameObject.Find("Main Camera").transform;
        transformCamera = Camera.main.transform;
        //preCameraPos = transformCamera.position;
        preCameraPos = new Vector3(0, -5, -10);
    }

    // Update is called once per frame
    void Update()
    {
        float bGMoveX = (preCameraPos.x - transformCamera.position.x) * scaleCamera2BGX;
        float bGMoveY = (preCameraPos.y - transformCamera.position.y) * scaleCamera2BGY;

        for (int i = 0; i < transformBackGrounds.Length; i++)
        {
            float bGTargetX = transformBackGrounds[i].position.x + bGMoveX * (1 + scaleBGsX * i);
            float bGTargetY = transformBackGrounds[i].position.y + bGMoveY * (1 + scaleBGsY * i);
            transformBackGrounds[i].position = new Vector3(bGTargetX, bGTargetY,
                                                            transformBackGrounds[i].position.z);

        }
        preCameraPos = transformCamera.position;
    }
}
