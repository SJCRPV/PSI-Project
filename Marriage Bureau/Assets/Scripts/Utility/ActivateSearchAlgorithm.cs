using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSearchAlgorithm : MonoBehaviour {

    private GameObject holderOfValues;

    private void OnLevelWasLoaded(int level)
    {
        holderOfValues.GetComponent<SearchAlgorithm>().enabled = true;
    }

    // Use this for initialization
    void Start () {
        holderOfValues = GameObject.Find("HolderOfValues");
	}
}
