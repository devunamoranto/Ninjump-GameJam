using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    [SerializeField]
    float thresholdspeed = 5;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            float speed = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            Debug.Log(speed);
            if(speed >= thresholdspeed){
                
                GetComponentInParent<enemyScript>().Die();
            }
        }
    }
}
