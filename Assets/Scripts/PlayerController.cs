using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private float speed;
    private int count;
    public int lifes;
    public Text countText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        speed = 40f;
        count = 0;
        lifes = 3;
        SetInitialPosition();
        updateScore();
    }

    private void Update() {
        if (transform.position.y < 20) {
            count++;

        }
        updateScore();
    }

    void FixedUpdate() {
        if (lifes > 0) {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x - Time.deltaTime * speed, -41f, 81f), transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + Time.deltaTime * speed, -41f, 81f), transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                transform.position += Time.deltaTime * speed * -transform.up;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + Time.deltaTime * speed, -50f, 33f), transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) { 
        switch(other.tag) {
            case "Enemy": 
                lifes--;
                break;
            case "Win":
                countText.text = "WINNER";
                break;
            default:
                break;
        }
        SetInitialPosition();
    }

    void SetInitialPosition() {
        Vector3 position = new Vector3(20f,30f,0);
        transform.position = position;
    }

    void updateScore() {
        if (lifes > 0) {
            countText.text = "Points: " + count + "\nLifes: " + lifes;
        } else {
            countText.text = "HIGHSCORE: " + count;
            countText.color = Color.red;
            countText.fontSize = 50;
        }
    }
}
