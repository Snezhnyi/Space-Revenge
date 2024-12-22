using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathToRoom02Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {   if(collision.gameObject.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().ToggleTilemap(true);
                GameObject.FindGameObjectWithTag("Door").GetComponent<DoorController>().room = GameObject.FindGameObjectWithTag("SecondRoom");
                GameObject.FindGameObjectWithTag("SecondRoom").GetComponent<RoomController>().startWave = true;
                GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom = 2;
                Destroy(this.gameObject);
            }
            
        }catch(System.Exception e)
        {
            Debug.Log(e.ToString());
        }
               
    }
}
