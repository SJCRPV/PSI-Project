using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SubmitPersonalInformation : MonoBehaviour {

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
    private ToggleGroup groupImportante;
    private ToggleGroup groupTracos;
    private ToggleGroup groupDefeitos;
    private ToggleGroup groupTemposLivres;

    /*private string extractName(IEnumerable<Toggle> currentToggle)
    {
        //currentToggle
        //return "";
    }*/

    private void gatherInput()
    {
        IEnumerable<Toggle> currentToggle = groupOlhos.ActiveToggles();
        Toggle test = currentToggle.FirstOrDefault();
        string tesitng = test.gameObject.name;
    }

    public void onClick()
    {
        gatherInput();
    }

    // Use this for initialization
    void Start () {
        inputIdade = GameObject.Find("Idade").GetComponent<InputField>();
        inputAltura = GameObject.Find("Alutra").GetComponent<InputField>();
        inputEtnia = GameObject.Find("Etnia").GetComponent<InputField>();
        inputProfissao = GameObject.Find("Profissão").GetComponent<InputField>();
        inputCorPreferida = GameObject.Find("CorPreferida").GetComponent<InputField>();
        inputMusica = GameObject.Find("EstiloMúsica").GetComponent<InputField>();
        inputIdolos = GameObject.Find("Idolos").GetComponent<InputField>();
        inputFilmes = GameObject.Find("Filmes").GetComponent<InputField>();

        groupOlhos = GameObject.Find("Olhos").GetComponent<ToggleGroup>();
        groupCorCabelo = GameObject.Find("CorCabelo").GetComponent<ToggleGroup>();
        groupAnimais = GameObject.Find("Animais").GetComponent<ToggleGroup>();
        groupFilhos = GameObject.Find("Filhos").GetComponent<ToggleGroup>();
        groupImportante = GameObject.Find("ImportanteSi").GetComponent<ToggleGroup>();
        groupTracos = GameObject.Find("Traços").GetComponent<ToggleGroup>();
        groupDefeitos = GameObject.Find("Defeitos").GetComponent<ToggleGroup>();
        groupTemposLivres = GameObject.Find("TemposLivres").GetComponent<ToggleGroup>();
    }
}
