using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI_Handler : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Image titleScreen;
    private AudioSource playerAudio;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip wrongSound;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(true);
        playerAudio = GetComponent<AudioSource>();

    }
    public void StartGame()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
    }

    public void Settings()
    {
        playerAudio.PlayOneShot(wrongSound, 2.0f);

    }



    public void QuitGame()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }






    public void LevelRotation()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
        //SceneManager.LoadScene("DR Scene2", LoadSceneMode.Single);
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();

    }

}
