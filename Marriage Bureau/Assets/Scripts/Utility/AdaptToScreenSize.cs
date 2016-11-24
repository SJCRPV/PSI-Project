using UnityEngine;
using System.Collections;

public class AdaptToScreenSize : MonoBehaviour {

    private RectTransform canvasTransform;
    private RectTransform objectTransform;

    private void adaptToScreenSize()
    {
        //Debug.Log("Canvas width: " + canvasTransform.rect.width + "\nCanvas height: " + canvasTransform.rect.height);
        objectTransform.sizeDelta = new Vector2(canvasTransform.rect.width, canvasTransform.rect.height);
    }

	// Use this for initialization
	void Start () {
        canvasTransform = gameObject.transform.parent.GetComponentInParent<RectTransform>();
        objectTransform = gameObject.GetComponent<RectTransform>();
        adaptToScreenSize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
