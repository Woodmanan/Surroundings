using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    GameManagerScript GM; 
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("hit checkpoint" + transform.position); 
            GM.respawnPoint = transform.position;
            //Debug.Log(GM.respawnPoint);

            Destroy(this.gameObject, 0.5f); 
        }  
    }
}
