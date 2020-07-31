using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public GameObject player;
    //public LevelComplete levelComplete;
    public static bool playerHasExited = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Player" && Input.GetButtonDown("Action"))
        {
            Debug.Log("Player in Exit");
            //GameObject.Destroy(player);
            playerHasExited = true;
        }
    }
}