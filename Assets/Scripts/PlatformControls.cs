using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControls : MonoBehaviour
{
    Rigidbody2D rb;
    float xAxis;
    float yAxis;

    
    private float jumpTimer;
    [SerializeField]
    float jumpcd= 3f;
    

    [SerializeField]
    float rotationScaling = 2f;
    [SerializeField]
    float velocityScaling = 4f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        jump();

        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        if (Input.GetKey("q"))
        {
            rotate(1);
        }
        if (Input.GetKey("e"))
        {
            rotate(-1);
        }
        if (Input.GetKeyUp("q") || (Input.GetKeyUp("e")))
        {
            resetVelocity();
        }
        limits();
        move();
    }

    void resetVelocity()
    {
        rb.angularVelocity = 0;
    }

    void limits()
    {
        if (rb.rotation > 45)
        {
            
            rb.rotation = 45;
            rb.angularVelocity = 0;
        }
        else if (rb.rotation < -45)
        {
            
            rb.rotation = -45;
            rb.angularVelocity = 0;
        }
    }
    void rotate(float dir)
    {
        rb.angularVelocity += rotationScaling * dir;
    }

    void move()
    {
        Vector2 movementVector = new Vector2(xAxis, yAxis) * Time.deltaTime;
        rb.velocity += velocityScaling * movementVector;
    }


    private void jump(){
        if(jumpTimer > 0){
            jumpTimer -= Time.deltaTime;
        }

        if(jumpTimer < 0){
            jumpTimer = 0;
        }


        if(jumpTimer == 0 && Input.GetKey(KeyCode.Space)){
            rb.velocity = new Vector2(0,5);
            jumpTimer = jumpcd;
        }
    }





}


