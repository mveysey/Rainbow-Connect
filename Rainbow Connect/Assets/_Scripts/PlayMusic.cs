using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayMusic : MonoBehaviour
{
    public Button yourButton;
    public GameObject songPlaying;
    public GameObject notPlaying1;
    public GameObject notPlaying2;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

void TaskOnClick()
{
        songPlaying.SetActive(true);
        notPlaying1.SetActive(false);
        notPlaying2.SetActive(false);
        canvas.SetActive(false);
}
}
