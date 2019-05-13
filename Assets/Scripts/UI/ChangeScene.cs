using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string sceneToLoad;

    public void LoadScene(string sceneName)
    {
        GameObject sceneTransition = GameObject.Find("Canvas/SceneTransition");
        sceneTransition.GetComponent<Animator>().SetTrigger("FadeOut");
        sceneTransition.gameObject.SetActive(true);
        sceneToLoad = sceneName;
        Invoke("Load", 0.1f);
    }

    void Load()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }


}
