using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool spaceKeyWasPressed;
    private float horizontalMovement;
    private Rigidbody getComponent;
    private int extraJumpPower;
    

    // Start is called before the first frame update
    void Start()
    {
     getComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Space)){
             spaceKeyWasPressed = true;
        
        }
        horizontalMovement = Input.GetAxis("Horizontal");


    }

    private void FixedUpdate()
    {
        getComponent.velocity = new Vector3(horizontalMovement, getComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (spaceKeyWasPressed)
        {
            int jumpPower = 5;
            if (extraJumpPower>0)
            {
                jumpPower *= 2;
                extraJumpPower--;
            }
            getComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            spaceKeyWasPressed = false;
        }
    
        
       
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            extraJumpPower++;
        }
    }

}
