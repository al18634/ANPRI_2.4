using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int TotalOvos;
    [SerializeField]
    int NrOvosDoNivel;
    [SerializeField]
    int OvosApanhadosNesteNivel;
    [SerializeField]
    Text DadosJogo;
    [SerializeField]
    GameObject MenuDerrota;
    [SerializeField]
    GameObject MenuPausa;
    private bool isPausaEnabled;
    public GameObject menuObjetivo;

    GameObject player;

    void Awake()
    {
        GameManager[] ops = GameObject.FindObjectsOfType<GameManager>();
        if (ops.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Time.timeScale = 0;

        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        NrOvosDoNivel = FindObjectsOfType<Apanhar>().Length;

        if (DadosJogo == null)
            DadosJogo = GameObject.FindGameObjectWithTag("TxtOvos").GetComponent<Text>();

        AtualizarDadosJogador();

        if (MenuDerrota == null)
            MenuDerrota = GameObject.FindGameObjectWithTag("MenuDerrota");

        if (MenuDerrota != null)
            MenuDerrota.SetActive(false);

        if (MenuPausa == null)
            MenuPausa = GameObject.FindGameObjectWithTag("MenuPausa");

        if (MenuPausa != null)
        {
            MenuPausa.SetActive(false);
            isPausaEnabled = false;
        }

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        OvosApanhadosNesteNivel = 0;
    }

    private void AtualizarDadosJogador()
    {
        if (DadosJogo != null)
            DadosJogo.text = "Ovos no nível: " + (NrOvosDoNivel - OvosApanhadosNesteNivel) + " | Total de ovos: " + TotalOvos;
    }

    public void recomecarNivel()
    {
        TotalOvos -= OvosApanhadosNesteNivel;
    }

    public void adicionaOvo()
    {
        TotalOvos++;
        OvosApanhadosNesteNivel++;
        AtualizarDadosJogador();
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().buildIndex == 0) || ((menuObjetivo != null) && (menuObjetivo.active == true))) return;

        AtualizarDadosJogador();

        if (player == null)
        {
            MenuDerrota.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPausaEnabled = !isPausaEnabled;

            if (isPausaEnabled)
            {
                Time.timeScale = 0;
            } else
            {
                Time.timeScale = 1;
            }

            MenuPausa.SetActive(isPausaEnabled);
        }

        if (NrOvosDoNivel == OvosApanhadosNesteNivel)
        {
            if (SceneManager.GetActiveScene().buildIndex<SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene("Menu");
        }
    }
}
