using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript GM = null; 
    GameObject player; 

    int playerLives;
    public int timeLeft;

    public Vector3 respawnPoint = Vector3.zero;

    [SerializeField] private TMPro.TextMeshProUGUI timer;

    private void Awake()
    {
        if (GM == null)
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
        print("Starting coroutine!");
        StartCoroutine("Countdown");
        print("Coroutine started!");
    }

    // Update is called once per frame
    void Update()
    {
        print("Does this work");
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

    private IEnumerator Countdown()
    {
        print("Started!");
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            print("This is working!");
            timeLeft--;
            timer.SetText("Time Left: " + timeLeft);
        }
        //Time is up, restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(respawnPoint, .5f);
    }
}
