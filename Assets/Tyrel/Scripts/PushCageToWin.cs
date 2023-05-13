using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCageToWin : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject helpText;
    [SerializeField] private AudioSource aSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        helpText.SetActive(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player hit cage");
            helpText.SetActive(false);
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            GameManager.instance.WinGame();
            aSource.Play();
        }
    }
}
