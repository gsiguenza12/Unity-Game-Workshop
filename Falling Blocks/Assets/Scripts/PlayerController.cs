using UnityEngine;

public enum ScreenWrap{ ON = 1, OFF = -1};

public class PlayerController : MonoBehaviour {
    public float speed = 7;
    public ScreenWrap screenWrap = ScreenWrap.OFF;
    public event System.Action OnPlayerDeath;

    float halfScreenWidth;
    float halfPlayerWidth;

    // Use this for initialization
    void Start() {
        halfPlayerWidth = transform.localScale.x / 2f;
        halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (screenWrap.Equals(ScreenWrap.ON)) {
            if (transform.position.x < -(halfScreenWidth + halfPlayerWidth)) {
                transform.position = new Vector2((halfScreenWidth + halfPlayerWidth), transform.position.y);
            }

            if (transform.position.x > (halfScreenWidth + halfPlayerWidth)) {
                transform.position = new Vector2(-(halfScreenWidth + halfPlayerWidth), transform.position.y);
            }
        } else if (screenWrap.Equals(ScreenWrap.OFF)) {
            if (transform.position.x < -(halfScreenWidth - halfPlayerWidth)) {
                transform.position = new Vector2(-(halfScreenWidth - halfPlayerWidth), transform.position.y);
            }

            if (transform.position.x > (halfScreenWidth - halfPlayerWidth)) {
                transform.position = new Vector2((halfScreenWidth - halfPlayerWidth), transform.position.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Falling Block")) {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }

            Destroy(gameObject);
        }
    }
}