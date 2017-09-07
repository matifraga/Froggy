using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        transform.position += Time.deltaTime * speed * -transform.right;
        if (transform.position.x < -57) {
            Vector3 init = new Vector3(157, 0,0);
            transform.position += init;
        }
    }
}
