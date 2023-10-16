using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float maxX = 3.6f;
    private const float minX = -3.65f;
    private float speed = 3f;
    private bool isShooting;
    [SerializeField] private ObjectPool objectPool;
    private float coolDown = 0.5f;
    private void Update() {
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX) {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.D) && transform.position.x < maxX) {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.Space) && !isShooting) {
            StartCoroutine(Shoot());
        }
    }
    
    private IEnumerator Shoot() {
        isShooting = true; 
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(coolDown);
        isShooting = false;
    }
}
