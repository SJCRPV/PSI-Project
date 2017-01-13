using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleContent : MonoBehaviour
{
    [SerializeField]
    private Color activeColour;
    [SerializeField]
    private Color inactiveColour;
    [SerializeField]
    private GameObject[] objectsToToggle;
    [SerializeField]
    private bool isActive;

    private void toggleObjets()
    {
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].transform.gameObject.SetActive(isActive);
        }
    }

    private void flipIsActive()
    {
        isActive = !isActive;
    }

    public void onClick()
    {
        flipIsActive();
        toggleObjets();
    }
}