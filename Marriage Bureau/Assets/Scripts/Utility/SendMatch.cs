using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMatch : MonoBehaviour {

    [SerializeField]
    private Sprite spriteToSwapToOnClick;

    private Button btn;
    private Image btnImage;
    private Text btnText;
    private GameObject holderOfValues;
    private InteractWithDB dbInteractionScript;
    private Dossier dossierScript;
    private LimitedProfile limitedProfileScript;
    private string textOfNotification;
    private string senderUsername;
    private string destinationUsername;

    private void swapButtonContents()
    {
        btnImage.sprite = spriteToSwapToOnClick;
        btnText.text = "Pedido Enviado";
        btnText.color = new Color32(0xF6, 0x1B, 0x6A, 0xFF);
    }

    private void sendNotification()
    {
        string[] varNames = { "sender", "receiver", "descricao", "isSeen" };
        string[] varValues = { senderUsername, destinationUsername, textOfNotification, "false" };
        dbInteractionScript.sendToDB("http://psiwebservice/sendNotification.php", varNames, varValues);
    }

    private void fetchUsernames()
    {
        senderUsername = dossierScript.Username;
        destinationUsername = limitedProfileScript.Username;
    }

    private void prepareContent()
    {
        fetchUsernames();
        textOfNotification = senderUsername + " gostaria de fazer match consigo.";
        sendNotification();
    }

    public void onClick()
    {
        prepareContent();
        swapButtonContents();
        sendNotification();
    }

	// Use this for initialization
	void Start () {
        btn = gameObject.GetComponent<Button>();
        btnImage = btn.GetComponent<Image>();
        btnText = btn.gameObject.GetComponentInChildren<Text>();
        holderOfValues = GameObject.Find("HolderOfValues");
        dbInteractionScript = holderOfValues.GetComponent<InteractWithDB>();
        dossierScript = GameObject.Find("User").GetComponent<Dossier>();
        limitedProfileScript = GetComponentInParent<LimitedProfile>();
	}
}
