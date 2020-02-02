using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrols : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private bool cycle;

    [SerializeField] private Vector3 offset;
    

    [SerializeField] private Vector3[] points;
    private Vector3 point1;
    private Vector3 point2;

    private float lerpAmount;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        if (points.Length < 2)
        {
            Debug.LogError("Not enought points for Patrolling!!");
        }
        point1 = transform.position;
        point2 = points[0] - offset;
        setUpPoints(point1, point2);
        count = 0;
    }

    void setUpPoints(Vector3 p1, Vector3 p2)
    {
        print("Setting up points " + point1 + ", " + point2);
        float dist = Vector3.Distance(p1, p2);
        float travelTime = dist / speed;
        lerpAmount = 1 / travelTime;
        IEnumerator coroutine = moveBetweenPoints(lerpAmount);
        StartCoroutine(coroutine);
        
    }

    IEnumerator moveBetweenPoints(float lerps)
    {
        for (float i = 0; i <= 1; i += lerps * Time.deltaTime)
        {
            transform.position = Vector3.Lerp(point1, point2, i);
            yield return null;
        }

        point1 = points[count] - offset;
        count++;
        if (count == points.Length)
        {
            if (cycle)
            {
                count = 0;
            }
            else
            { 
                count = 1;
                Vector3[] temp = new Vector3[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    temp[points.Length - i - 1] = points[i];
                }
                points = temp;
            }
            
        }
        point2 = points[count] - offset;
        setUpPoints(point1, point2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(points[i], .3f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(points[i], points[i + 1]);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(points[points.Length - 1], .3f);

        if (cycle)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(points[points.Length - 1], points[0]);
        }
    }
}
