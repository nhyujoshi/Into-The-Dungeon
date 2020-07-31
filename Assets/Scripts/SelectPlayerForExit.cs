using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerForExit : MonoBehaviour
{
    private bool SearchingForThePlayer = false;
    private GameObject Player;
    private ExitScript exitScript;
    void Start()
    {
        exitScript = GetComponent<ExitScript>();
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
        exitScript.player = Player;
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
            Player = Result.gameObject;
            SearchingForThePlayer = false;
            FixedUpdate();
            yield return null;
        }
    }
}
