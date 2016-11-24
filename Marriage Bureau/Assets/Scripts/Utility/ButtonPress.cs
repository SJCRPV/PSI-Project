using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {
    [SerializeField]
    private int sceneToLoadIndex;

    public void loadScene()
    {
        SceneManager.LoadScene(sceneToLoadIndex);
    }
}
