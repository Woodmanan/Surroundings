using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoacherScript : MonoBehaviour
{
    public int maxRotation = 90;

    public Quaternion start;

    public Quaternion target; 

    public float rotateSpeed = 1.0f;

    float rotation; 

    // Start is called before the first frame update
    void Start()
    {
        //rotation = -1 * (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        //target = Quaternion.Euler(0,  + rotation, 0);

        //start = transform.rotation;

        //StartCoroutine(Rotate()); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, maxRotation * Mathf.Sin(Time.time * rotateSpeed), 0); 
    }

    /*
    private IEnumerator Rotate()
    {
        float counter = 0;
        while (counter < rotateDuration)
        {
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(start, target, counter / rotateDuration);
            yield return null; 
        }

        Debug.Log("here"); 
        start = transform.rotation;
        rotation = -1 * (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        target = Quaternion.Euler(0, rotationDegree + rotation, 0);
        StartCoroutine(Rotate()); 
    }
    */ 
}
