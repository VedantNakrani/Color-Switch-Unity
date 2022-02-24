using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour {

    public float jumpForce = 8f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color[] colors = { new Color32(53, 226, 242, 255), new Color32(255, 0, 128, 255), new Color32(246, 223, 14, 255), new Color32(140, 19, 251, 255) };
    public string[] colorNames = {"Cyan", "Pink", "Yellow", "Magenta"}; 

    public AudioSource jumpSound;
    public AudioSource changeColorSound;
    public AudioSource deathSound;
    public AudioSource pointSound;

    public bool isGameOver = false;

    public Score sc;

    void Start() {
        isGameOver = false;
        Physics2D.gravity = new Vector2(0f, 0f);
        setRandomColor();
    }

    void Update() {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
            Physics2D.gravity = new Vector2(0f, -9.8f);
            if(!isGameOver) {
                if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpSound.Play();
                }
            }
        }
        if(!isGameOver) {
            if(transform.position.y <= -6) {
                isGameOver = true;
                deathSound.Play();
                StartCoroutine(delayAction(1));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.tag == "ColorChanger") {
            setRandomColor();
            changeColorSound.Play();
            Destroy(col.gameObject);
            return;
        }

        if(!isGameOver) {
            if(col.tag != "Points" && col.tag != currentColor) {
                isGameOver = true;
                deathSound.Play();
                StartCoroutine(delayAction(1));
            }

            if(col.tag == "Points") {
                sc.score = 1 + sc.score;
                pointSound.Play();
                Destroy(col.gameObject);
            }
        }
    }

    IEnumerator delayAction(float delayTime) {

        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void setRandomColor() {

        int index;
        do {
            index = Random.Range(0,4);
        } while(currentColor == colorNames[index]);

        sr.color = colors[index];
        currentColor = colorNames[index];
    }
}
