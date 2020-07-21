using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    private bool paused = false;
    private List<MonoBehaviour> scriptsToPause = new List<MonoBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        scriptsToPause.Add(GameObject.Find("Gun").GetComponent<Fire>());
        scriptsToPause.Add(GameObject.Find("Hero").GetComponent<PlayerControl>());
        scriptsToPause.Add(GameObject.Find("Hero").GetComponent<PlayerCrate>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            PauseResume();
    }

    public void PauseResume()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        GetComponent<Canvas>().enabled = paused;
        foreach (MonoBehaviour script in scriptsToPause)
            if (script)
                script.enabled = !paused;
    }
}
