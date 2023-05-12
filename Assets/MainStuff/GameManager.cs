using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GameStart")]
    [SerializeField] private GameObject mainCanvasBG;
    [SerializeField] private PlayableDirector mainCanvasDirector;


    

    // Start is called before the first frame update
    void Start()
    {
        mainCanvasBG.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        mainCanvasBG.SetActive(false);
        mainCanvasDirector.Play();

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
