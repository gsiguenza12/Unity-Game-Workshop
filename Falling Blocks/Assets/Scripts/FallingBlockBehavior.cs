using UnityEngine;

public class FallingBlockBehavior : MonoBehaviour {
    public Vector2 speedVariance;

    float speed;
    float visibleHeightThreshold;

    void Start() {
        speed = Mathf.Lerp(speedVariance.x, speedVariance.y, Difficulty.GetDifficultyPercent());

        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;

        GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.down * speed * 50);
    }

    void Update() {
        //transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

        if (transform.position.y < visibleHeightThreshold) {
            Destroy(gameObject);
        }
    }
}