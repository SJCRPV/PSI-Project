using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollToTop : MonoBehaviour {

    private Scrollbar scrollbarScript;

    public void moveToTop()
    {
        scrollbarScript.value = 1;
    }

	// Use this for initialization
	void Start () {
        scrollbarScript = GameObject.Find("Scrollbar").GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
