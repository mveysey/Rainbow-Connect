using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDialogue : MonoBehaviour
{
    public GameObject dialogue;

    void OnTriggerEnter(Collider other)
    {
        

        dialogue.SetActive(true);
        StartCoroutine(CloseScript());
        




    }

    public IEnumerator CloseScript()
    {
        yield return new WaitForSeconds(6f);
        dialogue.SetActive(false);
    }
}
