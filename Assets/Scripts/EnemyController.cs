using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    float speed;

    void Start() {
        rb = GetComponent<Rigidbody>();
        speed = 100f + Random.value * 50;
    }

    void FixedUpdate() {
        transform.position += Time.deltaTime * speed * -transform.right;

        if (transform.position.x < -57) {
            Vector3 init = new Vector3(157 + Random.value * 70, 0,0);
            transform.position += init;
        }
    }
}
