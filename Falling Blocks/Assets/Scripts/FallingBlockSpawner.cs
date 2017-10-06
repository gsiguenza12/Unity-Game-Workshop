using UnityEngine;

public class FallingBlockSpawner : MonoBehaviour {
    public GameObject fallingBlockPrefab;
    public Vector2 spawnIntervalVariance;

    public Vector2 spawnSizeVariance;
    public Vector2 spawnAngleVariance;

    float nextSpawnTime;
    Vector2 halfScreenWidth;

    // Use this for initialization
    void Start() {
        halfScreenWidth = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextSpawnTime) {
            float secondsBetweenSpawns = Mathf.Lerp(spawnIntervalVariance.y, spawnIntervalVariance.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(spawnAngleVariance.x, spawnAngleVariance.y);
            float spawnSize = Random.Range(spawnSizeVariance.x, spawnSizeVariance.y);

            Vector2 spawnPosition = new Vector2(Random.Range(-halfScreenWidth.x, halfScreenWidth.x), halfScreenWidth.y + spawnSize);

            GameObject newBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            newBlock.transform.localScale = Vector2.one * spawnSize;
        }

    }
}