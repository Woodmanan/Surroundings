using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript GM = null; 
    GameObject player; 

    int playerLives;
    float timeLeft;

    public Vector3 respawnPoint = Vector3.zero;

    private void Awake()
    {
        if (GM = null)
        {
            GM = this; 
        }
        else if (GM != this)
        {
            Destroy(this); 
        }

        DontDestroyOnLoad(this); 
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObject"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // kill player after some delay 
    void KillPlayer(float delay)
    {
        playerLives--; 

        if (playerLives <= 0)
        {
            // reload(reset) current scene 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
        else
        {
            Respawn(respawnPoint); 
        }
    }

    // respawn at certain point 
    void Respawn(Vector3 point)
    {
        player.transform.position = point; 
    }
}
