using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoacherScript : MonoBehaviour
{
    public int maxRotation = 90;


    private Quaternion start;

    private Quaternion target; 

    public float rotateSpeed = 1.0f;
    private Quaternion offsetQuat;

    private Patrols pat;

    float rotation; 

    // Start is called before the first frame update
    void Start()
    {
        //rotation = -1 * (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        //target = Quaternion.Euler(0,  + rotation, 0);

        //start = transform.rotation;

        //StartCoroutine(Rotate()); 
        offsetQuat = transform.rotation;//Quaternion.Euler(offset);
        pat = GetComponent<Patrols>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pat)
        {
            Vector3 dest = pat.getDestination();
            print("Dest is: " + dest);
            dest = dest - transform.position;
            Quaternion target = Quaternion.Euler(0, Mathf.Atan2(dest.z, dest.x) * Mathf.Rad2Deg, 0);
            transform.rotation = target;
        }
        else
        {
            transform.rotation = offsetQuat * Quaternion.Euler(0, maxRotation * Mathf.Sin(Time.time * rotateSpeed), 0);
        }
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
