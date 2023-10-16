using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienMaster : MonoBehaviour {
    private List<GameObject> allAliens = new List<GameObject>();
    private bool movingRight;

    private const float MAX_RIGT = 3.5f; 
    private const float MAX_LEFT = -3.6f;
    private Vector3 hMoveDistance = new Vector3 (0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.15f, 0);

    private float moveTimer = 0.125f;
    private const float MAX_MOVETIMER_SPEED = 0.02f;
    private float moveTime = 0.005f;
    private void Start() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Alien")) {
            allAliens.Add(obj);
        }
    }
    
    private void Update() {
        if(moveTimer <= 0) {
            // 60 fps bir oyunda saniyede 60 kere update fonksiyonu çalýþýr.
            // burada Alienlerimiz 0.05f haraketi 60 fps bir oyunda 60 kere yapar, yani 60 * 0.05 = 3.
            // X ekseninde saniye de 3 birim haraket eder ve oyunda çok hýzlý oluyor.Bu yüzden timer koyduk.
            MoveEnemies();
        }
        moveTimer -= Time.deltaTime;
    }

    private void MoveEnemies() {
        int hitmax = 0;
        if (allAliens.Count > 0) {
            for (int i = 0; i < allAliens.Count; i++) {
                if (movingRight) {
                    allAliens[i].transform.position += hMoveDistance;
                } else {
                    allAliens[i].transform.position -= hMoveDistance;
                }
                if (allAliens[i].transform.position.x >= MAX_RIGT || allAliens[i].transform.position.x <= MAX_LEFT) {
                    hitmax++;
                }
            }
            if(hitmax > 0) {
                for(int i = 0; i < allAliens.Count; i++) {
                    allAliens[i].transform.position -= vMoveDistance;
                }
                movingRight = !movingRight;
            }
        }
        moveTimer = GetMoveSpeed();
    }
    
    private float GetMoveSpeed() {
        // Alien sayýmýz azaldýkça timer'a dönen deðerde azalýyor
        // 25 * 0.005 = 0.125
        // 20 * 0.005 = 0.1
        // 10 * 0.005 = 0.05
        // Belli bir limitin altýndayken çok aþýrý hýzlanmamasý için MAX_MOVETIMER_SPEED deðiþkenimizi kullanýyoruz
        float f = allAliens.Count * moveTime;
        if(f < MAX_MOVETIMER_SPEED) {
            return MAX_MOVETIMER_SPEED;
        } else {
            return f;
        }
    }
}
