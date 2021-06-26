using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textbox : MonoBehaviour {

    static float pauseTime = 5.0f;

    // [TextArea] public string tempText;

    [SerializeField] private TextMeshPro textRenderer;
    [SerializeField] private SpriteRenderer textbox;
    [SerializeField] private SpriteRenderer textboxStem;


    void Start() {

    }

    void Update() {
        // Temporary Code Snippet
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    Say(tempText);
        //}
    }

    public void Say(string text) {
        ChangeTextboxState(true);
        StartCoroutine(ResizeBoxCoroutine());

    }

    void ResizeBox() {
        Vector2 dimensions = textRenderer.GetRenderedValues(true);
        textbox.size = new Vector2(dimensions.x + 3, dimensions.y + 3);
    }

    private void ChangeTextboxState(bool state) {
        textRenderer.enabled = state;
        textbox.enabled = state;
        textboxStem.enabled = state;
    }

    IEnumerator ResizeBoxCoroutine() {
        yield return new WaitForEndOfFrame();
        ResizeBox();
        yield return new WaitForSeconds(pauseTime);
        ChangeTextboxState(false);
    }
}