using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterPos : MonoBehaviour
{
    private float bulletDeactivatePos = 10f;

    private void Update() {
        if(transform.position.y >= bulletDeactivatePos || transform.position.y <= -bulletDeactivatePos) { 
            gameObject.SetActive(false);
        }
    }
}
