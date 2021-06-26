using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseAvatar : MonoBehaviour
{
    public Button yourButton;
    public GameObject box;
    public static int colour;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        box.SetActive(false);
        if (gameObject.CompareTag("orange")) {
            colour = 0;
        }
        if (gameObject.CompareTag("yellow")) {
            colour = 1;
        }
        if (gameObject.CompareTag("purple")) {
            colour = 2;
        }
        if (gameObject.CompareTag("green")) {
            colour = 3;
        }
        if (gameObject.CompareTag("blue")) {
            colour = 4;
        }
        if (gameObject.CompareTag("pink")) {
            colour = 5;
        }
    }

        public static int GetColour()
        {
        return colour;

        }
    }

