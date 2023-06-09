using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("WinGame")]
    [SerializeField] private GameObject WinCanvas;
    public bool PlayerWin = false;


    // Start is called before the first frame update
    void Start()
    {
        mainCanvasBG.SetActive(true);
        pauseCanvas.SetActive(false);
        WinCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && gameStarted && !PlayerWin)
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


    public void WinGame()
    {
        
        WinCanvas.SetActive(true);
        PlayerWin = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        gameIsPaused = false;
        pauseCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        Debug.Log("show Pause game");
        gameIsPaused = true;
        pauseCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void startGame()
    {
        Debug.Log("Starting Game");
        mainCanvasBG.SetActive(false);
        mainCanvasDirector.Play();
        gameStarted = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game");
        SceneManager.LoadScene("0");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
