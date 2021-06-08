using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuDefinicoes;
    public GameObject menuCreditos;
    public GameObject menuPausa;
    public GameObject menuControlos;
    public GameObject menuObjetivo;

    void Start()
    {
        menuPrincipal.SetActive(true);
        menuDefinicoes.SetActive(false);
        menuCreditos.SetActive(false);
        menuControlos.SetActive(false);
    }

    public void Menu_BotaoIniciar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Menu_BotaoDefinicoes()
    {
        menuPrincipal.SetActive(false);
        menuDefinicoes.SetActive(true);
    }

    public void Menu_BotaoSairDefinicoes()
    {
        menuPrincipal.SetActive(true);
        menuDefinicoes.SetActive(false);
    }

    public void Menu_BotaoCreditos()
    {
        menuPrincipal.SetActive(false);
        menuCreditos.SetActive(true);
    }

    public void Menu_BotaoSairCreditos()
    {
        menuPrincipal.SetActive(true);
        menuCreditos.SetActive(false);
    }

    public void Menu_BotaoSair()
    {
        Application.Quit();
    }

    public void Menu_ReiniciarJogo()
    {
        FindObjectOfType<GameManager>().recomecarNivel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu_ContinuarJogo()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu_VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Menu_BotaoControlos()
    {
        menuPrincipal.SetActive(false);
        menuControlos.SetActive(true);
    }

    public void Menu_BotaoSairControlos()
    {
        menuPrincipal.SetActive(true);
        menuControlos.SetActive(false);
    }

    public void Menu_AvancarProJogo()
    {
        menuObjetivo.SetActive(false);
        Time.timeScale = 1;
    }
}
