using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    // up here we set up the image we want to fade out, the time it should take (in this case 2f seconds) and we make the Color to what color we want to fade it to.
    public float fadeTime = 2f;

    private Image fadePanel;
    private Color colorToFadeTo;

	// Use this for initialization
	void Start () {
        // here we fade to color basically black, with 0f on the Alpha to make it completely transparent. Afterwards we tell the panel to do CrossFadeColor using the time fadeTime. We tell it to use the alpha too.
        colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        fadePanel = gameObject.GetComponent<Image>();
        fadePanel.CrossFadeColor(colorToFadeTo, fadeTime, true, true);

        StartCoroutine(LateCall());
	}
	
	IEnumerator LateCall()
    {
        yield return new WaitForSeconds(fadeTime);
        gameObject.SetActive(false);
    }
}
