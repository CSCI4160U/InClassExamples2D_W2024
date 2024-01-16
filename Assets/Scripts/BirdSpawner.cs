using UnityEngine;

public class BirdSpawner : MonoBehaviour {
    [Header("Spawn Zone")]
    [SerializeField] private float minimumX = -4f;
    [SerializeField] private float maximumX = 4f;
    [SerializeField] private float minimumY = -5f;
    [SerializeField] private float maximumY = 5f;

    [Header("Spawn Properties")]
    [SerializeField] private GameObject birdPrefab;
    [SerializeField] private int numToSpawn = 20;

    [ContextMenu("Spawn")]
    public void Spawn() {
        if (birdPrefab == null) return;

        for (int i = 0; i < numToSpawn; i++) {
            // generate a spawn location
            float xOffset = Random.Range(minimumX, maximumX);
            float yOffset = Random.Range(minimumY, maximumY);
            Vector3 birdPos = transform.position + new Vector3(xOffset, yOffset, 0f);

            // spawn a new bird
            GameObject newBird = Instantiate(birdPrefab, birdPos, Quaternion.identity);

            // set us as the parent object
            newBird.transform.SetParent(transform);
        }
    }
}

