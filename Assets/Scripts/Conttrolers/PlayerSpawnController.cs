using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnController : MonoBehaviour
{
    public GameObject player, spawnPoint;
    public int CurrentSpawnPointOfThePlayer = 1;
    // Start is called before the first frame update

    public int delayScene = 2;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            spawnPoint = VerifySpawnPoint();
            player = Instantiate(Resources.Load("Ships/Player") as GameObject, this.spawnPoint.transform.position, this.spawnPoint.transform.rotation);
            //player.GetComponent<PlayerStateController>().barsControllers = gameObject.AddComponent<BarsController>();
            player.GetComponent<PlayerStateController>().barsControllers = GameObject.Find("Bars").GetComponent<BarsController>() as BarsController;
            player.tag = "Player";
           
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(player == null)
        {
            StartCoroutine(ChangeSceneWithDelay(delayScene));
        }
        
    }

    IEnumerator ChangeSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver"); 
    }

    public GameObject VerifySpawnPoint()
    {
        if (this.CurrentSpawnPointOfThePlayer == 1)
        {
            return this.transform.Find("PlayerOneSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 2)
        {
            return this.transform.Find("PlayerTwoSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 3)
        {
            return this.transform.Find("PlayerThreeSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 4)
        {
            return this.transform.Find("PlayerFourSpawnPoint").gameObject;
        }
        else if (this.CurrentSpawnPointOfThePlayer == 5)
        {
            return this.transform.Find("PlayerFiveSpawnPoint").gameObject;
        }
        return this.transform.Find("PlayerOneSpawnPoint").gameObject;
    }
}
