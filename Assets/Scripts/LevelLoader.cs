using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

   

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }*/
    }

    public void LoadNextLevel()
    {
        // Instead of this:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void NextScreen()
    {
        StartCoroutine( ScreenTransition());
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator ScreenTransition()
    {
        // Play animation
        transition.SetTrigger("End");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        
        transition.SetTrigger("Start");

    }
    
}
