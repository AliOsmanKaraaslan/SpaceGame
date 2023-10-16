using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour {
    private float bulletSpeed = 10f;
    private void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);
    }
}
