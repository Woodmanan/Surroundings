using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components we need
    private Rigidbody rigid;


    //Serialized Variables
    [SerializeField] private float speed;
    [SerializeField] private float speedSprinting = 1;
    [SerializeField] private float lerpAmount;
    [SerializeField] private string horizontalAxis = "Horizontal";
    [SerializeField] private string verticalAxis = "Vertical";

    //Private Variables
    private Vector2 direction = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Need to be worried about what having animations will look like
        //Animations will push us forward when they move, so we should always be moving forward
        //And turning to match the proposed direction

        direction = new Vector2(Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis));
        if (direction.magnitude > 1)
        {
            direction = direction.normalized;
        }

        if (direction.magnitude > 0.1)
        {
            //We need to rotate
            float targetRotation = -1 * Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion newDirection = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, newDirection, lerpAmount);

            //Now we need to move
            //Determines the 2D velocity
            
            
            float rotation = -1 * (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
            Vector2 xyVelocity;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                xyVelocity = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation)) * speed * speedSprinting;
            }
            else
            {
                xyVelocity = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation)) * speed;
            }

            //Translate it to the 3D one
            Vector3 rigidVelocity = new Vector3(xyVelocity.x, rigid.velocity.y, xyVelocity.y);
            rigid.velocity = rigidVelocity;
            

            
        }
        else
        {
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
            //We're Idling! This is a stub for where the animation will go
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector3(direction.x + transform.position.x, transform.position.y, direction.y + transform.position.z));

        float rotation = -1 * (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + Mathf.Cos(rotation), transform.position.y, transform.position.z + Mathf.Sin(rotation)));
    }
}
