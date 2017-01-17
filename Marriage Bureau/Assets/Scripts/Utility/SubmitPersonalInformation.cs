using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SubmitPersonalInformation : MonoBehaviour {

    private InteractWithDB dbInteractionScript;
    private string username;

    //Input Fields
    private InputField inputIdade;
    private InputField inputAltura;
    private InputField inputEtnia;
    private InputField inputProfissao;
    private InputField inputCorPreferida;
    private InputField inputMusica;
    private InputField inputIdolos;
    private InputField inputFilmes;

    //Group Toggles
    private ToggleGroup groupOlhos;
    private ToggleGroup groupCorCabelo;
    private ToggleGroup groupAnimais;
    private ToggleGroup groupFilhos;

    //Groups that allow multiple toggles
    private GameObject groupImportante;
    private GameObject groupTracos;
    private GameObject groupDefeitos;
    private GameObject groupTemposLivres;

    //Strings
    private string idade;
    private string altura;
    private string etnia;
    private string profissao;
    private string corPreferida;
    private string olhos;
    private string corCabelo;
    private string filhos;
    private string animais;
    private string musica;
    private string idolos;
    private string filmes;
    private string temposLivres;
    private string defeitos;
    private string tracos;
    private string importante;

    private string[] extractActiveToggles(GameObject toggleParent)
    {
        string temp = "";
        for(int i = 0; i < toggleParent.transform.childCount; i++)
        {
            if(toggleParent.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                temp += toggleParent.transform.GetChild(i).gameObject.name + ",";
            }
        }
        return temp.Split(',');
    }

    private string[] extractStringArray(string inputText)
    {
        return inputText.Split(',');
    }

    private string extractName(IEnumerable<Toggle> currentToggle)
    {
        Toggle temp = currentToggle.FirstOrDefault();
        return temp.gameObject.GetComponentInChildren<Text>().text;
    }

    private string compoundToString(string[] arrayString)
    {
        string temp = "";
        for(int i = 0; i < arrayString.Length; i++)
        {
            temp += arrayString[i];
        }
        return temp;
    }

    private string resolveBoolean(string stringedBool)
    {
        if (stringedBool.Equals("Sim"))
        {
            return "1";
        }
        else
        {
            return "0";
        }
    }

    private IEnumerator sendToDB()
    {
        string[] varNames = new string[] { "username", "idade", "altura", "etnia", "profissao", "corPreferida", "olhos", "corCabelo", "filhos", "animais", "musica", "idolos", "filmes", "temposLivres", "defeitos", "tracos", "importante" };
        string[] varValues = new string[] { username, idade, altura, etnia, profissao, corPreferida, olhos, corCabelo, filhos, animais, musica, idolos, filmes, temposLivres, defeitos, tracos, importante };
        dbInteractionScript.sendToDB("http://psiwebservice/registerInformation.php", varNames, varValues);
        while (dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
        Debug.Log(dbInteractionScript.CleanData[0]);
    }

    private void gatherInput()
    {
        idade = inputIdade.text;
        altura = inputAltura.text;
        etnia = inputEtnia.text;
        musica = inputMusica.text;
        idolos = inputIdolos.text;
        filmes = inputFilmes.text;
        profissao = inputProfissao.text;
        corPreferida = inputCorPreferida.text;
        olhos = extractName(groupOlhos.ActiveToggles());
        corCabelo = extractName(groupCorCabelo.ActiveToggles());
        filhos = resolveBoolean(extractName(groupFilhos.ActiveToggles()));
        temposLivres = compoundToString(extractActiveToggles(groupTemposLivres));
        defeitos = compoundToString(extractActiveToggles(groupDefeitos));
        tracos = compoundToString(extractActiveToggles(groupTracos));
        importante = compoundToString(extractActiveToggles(groupImportante));
        animais = resolveBoolean(extractName(groupAnimais.ActiveToggles()));
        StartCoroutine(sendToDB());
    }

    public void onClick()
    {
        username = GameObject.Find("HolderOfValues").GetComponent<HoldAndSendLoginValues>().Username;
        gatherInput();
    }

    // Use this for initialization
    void Start () {
        dbInteractionScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();

        inputIdade = GameObject.Find("Idade").GetComponentInChildren<InputField>();
        inputAltura = GameObject.Find("Altura").GetComponentInChildren<InputField>();
        inputEtnia = GameObject.Find("Etnia").GetComponentInChildren<InputField>();
        inputProfissao = GameObject.Find("Profissão").GetComponentInChildren<InputField>();
        inputCorPreferida = GameObject.Find("CorPreferida").GetComponentInChildren<InputField>();
        inputMusica = GameObject.Find("EstiloMúsica").GetComponentInChildren<InputField>();
        inputIdolos = GameObject.Find("Idolos").GetComponentInChildren<InputField>();
        inputFilmes = GameObject.Find("Filmes").GetComponentInChildren<InputField>();

        groupOlhos = GameObject.Find("Olhos").GetComponent<ToggleGroup>();
        groupCorCabelo = GameObject.Find("CorCabelo").GetComponent<ToggleGroup>();
        groupAnimais = GameObject.Find("Animais").GetComponent<ToggleGroup>();
        groupFilhos = GameObject.Find("Filhos").GetComponent<ToggleGroup>();

        groupImportante = GameObject.Find("ImportanteSi");
        groupTracos = GameObject.Find("Traços");
        groupDefeitos = GameObject.Find("Defeitos");
        groupTemposLivres = GameObject.Find("TemposLivres");
    }
}
