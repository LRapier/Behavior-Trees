using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Toggle unlocked;
    public Toggle angry;
    public int sceneToLoad = 1;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        unlocked = GameObject.FindGameObjectWithTag("Unlocked").GetComponent<Toggle>();
        angry = GameObject.FindGameObjectWithTag("Angry").GetComponent<Toggle>();
    }
    public void Load()
    {
        SceneManager.LoadScene(sceneToLoad);
        if (sceneToLoad == 1)
            sceneToLoad = 0;
        else
            Destroy(this.gameObject);
    }
}
