using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private float speed;
    private int count;
    public int lives;
    private int timer;
    public Text countText;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;


    void Start() {
        rb = GetComponent<Rigidbody>();
        speed = 40f;
        count = 0;
        timer = 0;
        lives = 3;
        SetInitialPosition();
    }

    void FixedUpdate() {
        if (lives > 0)
        {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x - Time.deltaTime * speed, -41f, 81f), transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + Time.deltaTime * speed, -41f, 81f), transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Time.deltaTime * speed * -transform.up;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + Time.deltaTime * speed, -50f, 37f), transform.position.z);
            }
        } else
        {
            timer++;
            if (timer > 180)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) { 
        switch(other.tag) {
            case "Enemy":
                if (lives == 3)
                    live1.SetActive(false);
                else if (lives == 2)
                    live2.SetActive(false);
                else if (lives == 1)
                {
                    countText.text = "You lose, S: " + count;
                    live3.SetActive(false);
                }
                lives--;
                break;
            case "Win":
                count++;
                countText.text = count.ToString();
                break;
            default:
                break;
        }
        SetInitialPosition();
    }

    void SetInitialPosition() {
        Vector3 position = new Vector3(20f,35f,0);
        transform.position = position;
    }
}
