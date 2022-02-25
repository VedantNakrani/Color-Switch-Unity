using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {
    public GameObject circle;
    public GameObject star;
    public GameObject colorChanger;

    public Score sc;
    int prevScore = 0;
    int i = 0;

    void Start() {
        SpawnCircle(0);
        SpawnCircle(6);
    }

    void Update() {
        if(sc.score > prevScore) {
            SpawnCircle((sc.score + 1) * 6);
            prevScore = sc.score;
        }
    }

    void SpawnCircle(int positionY) {
        Instantiate(circle, transform.position + new Vector3(0, positionY, 0), transform.rotation * Quaternion.Euler(Vector3.forward * 100));
        Instantiate(star, transform.position + new Vector3(0, positionY, 0), transform.rotation);
        Instantiate(colorChanger, transform.position + new Vector3(0, positionY + 2, 0), transform.rotation);
    }
}
