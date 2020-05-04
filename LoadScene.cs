using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Button startButton;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(loadNextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadNextScene()
    {
        Debug.Log("Button test");
        SceneManager.LoadScene(sceneName);
    }
}
