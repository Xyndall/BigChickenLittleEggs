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
    [SerializeField] private GameObject CinematicCamera;
    public bool gameStarted = false;
    public bool TimelinePLaying = false;

    [Header("Pause")]
    [SerializeField] private GameObject pauseCanvas;
    public bool gameIsPaused;

    [Header("WinGame")]
    [SerializeField] private GameObject WinCanvas;
    public bool PlayerWin = false;

    [Header("PlayerStuff")]
    public bool playerIsChicken = true;
    [SerializeField] private GameObject GameCanvas;
    [SerializeField] private GameObject musicPlayer;
    [SerializeField] private GameObject PlayerCamera;
    public GameObject lastPlayerCheckpoint;
    public GameObject Player;




    // Start is called before the first frame update
    void Start()
    {
        mainCanvasBG.SetActive(true);
        pauseCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        musicPlayer.SetActive(true);
        CinematicCamera.SetActive(true);
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

        if (playerIsChicken)
        {
            GameCanvas.SetActive(true);
        }
        else
        {
            GameCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && TimelinePLaying)
        {
            mainCanvasDirector.Stop();
            TimelinePLaying = false;
            PlayerCamera.SetActive(true);
            playerIsChicken = true;
            CinematicCamera.SetActive(false);
            gameStarted = true;
        }

    }

    public void RespawnNewEgg()
    {
        
        GameObject newPlayer = Instantiate(Player, lastPlayerCheckpoint.GetComponent<Checkpoint>().checkpointSpawn.position, Quaternion.identity);
        newPlayer.GetComponent<PlayerCheckpoint>().LastCheckpoint = lastPlayerCheckpoint;
        GameManager.instance.playerIsChicken = false;
    }

    public void SetBoolTimeline()
    {
        Debug.Log("Setting bool true");
        TimelinePLaying = true;
    }

    public void WinGame()
    {
        WinCanvas.SetActive(true);
        PlayerWin = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        musicPlayer.SetActive(false);
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
