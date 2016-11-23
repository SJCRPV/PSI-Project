using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollToPosition : MonoBehaviour {

    private Scrollbar scrollbarScript;

    public void moveToTop()
    {
        scrollbarScript.value = 1;
    }

    public void moveToPosition(float newPos)
    {
        scrollbarScript.value = newPos;
    }

	// Use this for initialization
	void Start () {
        scrollbarScript = GameObject.Find("Scrollbar").GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
