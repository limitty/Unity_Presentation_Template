using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  public Animator transition;
  public float transitionTime = 1f;
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Return))
    {
      LoadNextLevel();
    }
  }

  public void LoadNextLevel()
  {
    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    Debug.Log("transition starts");
  }

  IEnumerator LoadLevel(int levelIndex)
  {
    transition.SetTrigger("Start");
    yield return new WaitForSeconds(transitionTime);
    Debug.Log("transitionTime: " + transitionTime);
    Debug.Log("Loading level...");
    SceneManager.LoadScene(levelIndex);
  }
}
