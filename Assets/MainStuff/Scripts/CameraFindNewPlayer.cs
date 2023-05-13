using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFindNewPlayer : MonoBehaviour
{
    #region singleton
    public static CameraFindNewPlayer instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    CinemachineFreeLook playerCam;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<CinemachineFreeLook>();
    }


    public void FindPlayer(Transform player)
    {

        playerCam.LookAt = player;
        playerCam.Follow = player;
    }

}
