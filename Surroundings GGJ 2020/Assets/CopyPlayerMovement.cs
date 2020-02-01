using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayerMovement : MonoBehaviour
{
    private Transform player;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float lerpAmount;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (offset.magnitude == 0 || lerpAmount == 0)
        {
            Debug.LogError("Camera settings don't seem to be set correctly");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, lerpAmount);
    }
}
