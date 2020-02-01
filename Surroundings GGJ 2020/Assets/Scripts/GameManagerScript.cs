using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript GM = null; 
    GameObject player; 

    int playerLives;
    public float timeLeft;

    public Vector3 respawnPoint = Vector3.zero;

    [SerializeField] private TMPro.TextMeshProUGUI timer;
    [SerializeField] private GameObject[] objectsToDesaturate;
    private Material[] materialsToDesaturate;

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

        DontDestroyOnLoad(this); 
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObject");

        materialsToDesaturate = new Material[objectsToDesaturate.Length];
        for (int i = 0; i < objectsToDesaturate.Length; i++)
        {
            print("i = " + i);
            materialsToDesaturate[i] = objectsToDesaturate[i].GetComponent<MeshRenderer>().materials[0];
        }

        //Set up floats
        foreach (Material m in materialsToDesaturate)
        {
            print("Setting floats!");
            print(m.name);
            print(m.GetFloat("_CurrentTime"));
            m.SetFloat("_CurrentTime", timeLeft);
            m.SetFloat("_MaxTime", timeLeft);
        }


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
            foreach (Material m in materialsToDesaturate)
            {
                print("Setting a material: " + m.name);
                m.SetFloat("_CurrentTime", timeLeft);
                print("Current is " + m.GetFloat("_CurrentTime"));
            }
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
