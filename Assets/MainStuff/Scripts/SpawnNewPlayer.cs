using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewPlayer : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Transform playerSpawn;
    public AudioSource aSource;
    public AudioClip[] aclip;

    public float timeRemaining = 10;
    public bool timerIsRunning = true;

    private void Start()
    {
        timerIsRunning = true;
        aSource.PlayOneShot(aclip[0]);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.playerIsChicken)
        {
            spawnNewEgg();
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

            }
            else if (timeRemaining <= 0)
            {
                aSource.PlayOneShot(aclip[0]);
                timeRemaining = 30;
                
            }
        }
    }

    void spawnNewEgg()
    {
        aSource.PlayOneShot(aclip[1]);
        Instantiate(Player, playerSpawn.position, Quaternion.identity) ;
        GameManager.instance.playerIsChicken = false;
    }
}