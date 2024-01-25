using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void Update()
    {
        transform.position = new Vector3(
            target.transform.position.x,
            target.transform.position.y,
            transform.position.z
        );
    }
}
