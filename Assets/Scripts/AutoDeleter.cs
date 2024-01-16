using UnityEngine;

public class AutoDeleter : MonoBehaviour
{
    [SerializeField] private float fallDistanceToDelete = 20f;

    private float originalY;

    private void Start() {
        originalY = transform.position.y;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.y - originalY) > fallDistanceToDelete) {
            Destroy(gameObject, 0.1f);
        }        
    }
}
