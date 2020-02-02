using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript GM = null; 
    GameObject player; 

    int playerLives;
    public float timeLeft;
    private float maxTime;

    public Vector3 respawnPoint = Vector3.zero;

    public Volume vol;
    private ColorAdjustments colors;

    [SerializeField] private TMPro.TextMeshProUGUI timer;

    

    private void Awake()
    {
        if (GM == null)
        {
            GM = this; 
        }
        else if (GM != this)
        {
            Destroy(this.gameObject); 
        }

        //Commenting this until we decide we need it to repeat for every scene
        //DontDestroyOnLoad(this); 
    }

    // Start is called before the first frame update
    void Start()
    {
        maxTime = timeLeft;
        vol = GetComponent<Volume>();
        colors = (ColorAdjustments) vol.profile.components[2];
        colors.saturation.value = -50f;
        player = GameObject.Find("PlayerObject");


        StartCoroutine("Countdown");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // kill player after some delay 
    public void KillPlayer(float delay)
    {
        playerLives--; 

        if (playerLives <= 0)
        {
            // reload(reset) current scene 
            Invoke("ReloadScene", delay); 
        }
        else
        {
            Invoke("Respawn", delay); 
        }
    }

    // respawn at certain point 
    void Respawn()
    {
        player.transform.position = respawnPoint; 
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator Countdown()
    {
        timeLeft += 1;
        print("Started Timer!");
        while (timeLeft > 0)
        {
            timeLeft--;
            timer.SetText("Time Left: " + timeLeft);
            colors.saturation.value =  (1 - (timeLeft / maxTime)) * -100;
            yield return new WaitForSeconds(1f);
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
