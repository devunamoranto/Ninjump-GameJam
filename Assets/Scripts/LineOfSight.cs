using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            GetComponentInParent<enemyScript>().playerrb = col.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("Seen player");
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
          if(col.CompareTag("Player")){
            GetComponentInParent<enemyScript>().playerrb = null;
            Debug.Log("unseen");
        }  
    }
}
