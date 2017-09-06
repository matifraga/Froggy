using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private float speed;
    private int count;
    public Text countText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        speed = 40f;
        count = 0;
        updateScore();
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Time.deltaTime * speed * -transform.right;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Time.deltaTime * speed * transform.right;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            transform.position += Time.deltaTime * speed * -transform.up;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            transform.position += Time.deltaTime * speed * transform.up;
        }
    }

    void OnTriggerEnter2D(Collider2D other) { //TODO: search clamp usage
        if (other.tag.Equals("Enemy")) {
            countText.text = "LOSER";
            transform.position = new Vector3(0, 0, 0);
        }
    }

    void updateScore() {
        countText.text = "Points: " + count;
    }
}
