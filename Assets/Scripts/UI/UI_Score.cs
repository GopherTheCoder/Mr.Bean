using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    private Text text;
    private int score = 0;

    private void Start() => text = GetComponent<Text>();

    public void AddScore(int add)
    {
        score += add;
        text.text = score.ToString();
    }
}
