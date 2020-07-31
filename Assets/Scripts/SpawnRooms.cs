using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour
{

    public LayerMask whatIsRoom;
    public LevelGeneration levelGen;
    //private IEnumerator scanCo;
    //private bool scanCoroutineStarted = false;

    //void Start()
    //{
    //    scanCo = ScanGraphCoroutine();
    //    StartCoroutine(scanCo);
    //}
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if(roomDetection == null && levelGen.stopGeneration == true)
        {
            //Spawn Random Room
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject); 
        }
        if (GameObject.FindGameObjectsWithTag("Room").Length == 16)
        {
            AstarPath.active.Scan();
            enabled = false;
        }
    }

    //IEnumerator ScanGraphCoroutine()
    //{
    //    //scanCoroutineStarted = true;
    //    AstarPath.active.Scan();
    //    yield return new WaitForSeconds(2);
    //}

    //void StopScanGraphCoroutine()
    //{
    //    StopCoroutine(scanCo);
    //}
}

