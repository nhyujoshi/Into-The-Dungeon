using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SelectPlayerAnimation : MonoBehaviour
{
    private bool SearchingForThePlayer = false;
    private Animator Player;
    private CinemachineStateDrivenCamera animTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        animTarget = GetComponent<CinemachineStateDrivenCamera>();
    }

    void FixedUpdate()
    {
        if (Player == null)
        {
            if (!SearchingForThePlayer)
            {
                SearchingForThePlayer = true;
                StartCoroutine(FindingThePlayer());

            }
            return;
        }
        animTarget.m_AnimatedTarget = Player;
    }

    IEnumerator FindingThePlayer()
    {
        GameObject Result = GameObject.FindGameObjectWithTag("Player");
        if (Result == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FindingThePlayer());
        }
        else
        {
            Player = Result.GetComponent<Animator>();
            SearchingForThePlayer = false;
            FixedUpdate();
            yield return null;
        }
    }
}
