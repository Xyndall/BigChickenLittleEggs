using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public Timer timer;
    public float health = 30;

    [SerializeField] private GameObject Chicken;

    // Start is called before the first frame update
    void Start()
    {
        timer.GetComponent<Timer>();
        timer.timeRemaining = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.timeRemaining <= 0)
        {
            Debug.Log("hatch egg");
            GameObject newChicken = Instantiate(Chicken, transform.position, Quaternion.identity);
            newChicken.GetComponent<SpawnNewPlayer>().checkpoint = this.gameObject.GetComponent<PlayerCheckpoint>().LastCheckpoint;
            GameManager.instance.playerIsChicken = true;
            Destroy(gameObject);
        }
    }
}
