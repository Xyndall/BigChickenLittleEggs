using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    [Header("GameStart")]
    [SerializeField] private GameObject mainCanvasBG;
    [SerializeField] private PlayableDirector mainCanvasDirector;
    public bool gameStarted = false;

    [Header("Pause")]
    [SerializeField] private GameObject pauseCanvas;
    public bool gameIsPaused;
    

    // Start is called before the first frame update
    void Start()
    {
        mainCanvasBG.SetActive(true);
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && gameStarted)
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void ResumeGame()
    {
        gameIsPaused = false;
        pauseCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        pauseCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void startGame()
    {
        mainCanvasBG.SetActive(false);
        mainCanvasDirector.Play();
        gameStarted = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
