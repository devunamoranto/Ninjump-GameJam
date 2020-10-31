using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    private float movespeed;

    Rigidbody2D rb;

    public Rigidbody2D playerrb;



    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

    }



    // Update is called once per frame
    void Update()
    {

        

        Move();
        
    }


    private void Move(){
        Vector2 direction;
        if(playerrb == null){
            rb.velocity = 0.99f * rb.velocity;
            return;
        } else {
            direction = (playerrb.transform.position - transform.position).normalized * Time.deltaTime;
            
            rb.velocity += direction * movespeed ;
        }
    }


    public Vector2 RandomUnitVector()
    {
        float random = Random.Range(0f, 360f);
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }

    public void Die(){
        Destroy(this.gameObject);
    }

}
