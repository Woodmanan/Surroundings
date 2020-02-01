using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAlignScript : MonoBehaviour
{
    public float errorMargin = 2.0f;

    //public float rotationDelta = 0.2f;

    public float rotateSpeed = 10.0f; 

    private Quaternion solution = Quaternion.identity; // zero

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        // change the rotation for puzzle 
        // POSSIBLE TODO: RANDOMIZE 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // decrease Y rotation 
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime); 
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // increase Y rotation 
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime); 
        }

        if (Input.GetKey(KeyCode.W))
        {
            // increase X rotation 
            transform.Rotate(-Vector3.right * rotateSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            // decrease X rotation 
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }

        // check current rotation against solution w/ error margin
        if (Quaternion.Angle(transform.rotation, solution) <= errorMargin)
        {
            Debug.Log("finished puzzle!11!"); 
            // win? 
        }
    }
}
