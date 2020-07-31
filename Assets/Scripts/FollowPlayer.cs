using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowPlayer : MonoBehaviour
{
    private bool SearchingForThePlayer = false;
    private Transform Player;
    private CinemachineVirtualCamera Vcam;

    // Start is called before the first frame update
    void Start()
    {
        Vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void FixedUpdate()
    {
        if(Player == null)
        {
            if (!SearchingForThePlayer)
            {
                SearchingForThePlayer = true;
                StartCoroutine(FindingThePlayer());

            }
            return;
        }
        Vcam.Follow = Player;
    }

    IEnumerator FindingThePlayer()
    {
        GameObject Result = GameObject.FindGameObjectWithTag("Player");
        if(Result == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FindingThePlayer());
        }
        else
        {
            Player = Result.transform;
            SearchingForThePlayer = false;
            FixedUpdate();
            yield return null;
        }
    }
}
