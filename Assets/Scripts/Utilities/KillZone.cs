using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other) {
        
        Destroy(other.gameObject);

    }


}
