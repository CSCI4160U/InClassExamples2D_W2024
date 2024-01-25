using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Slider playerHealth;
    private CharacterController2D controller;

    private float timeSinceLastTurn;
    private float turnDuration = 2f;

    private float velocity = 2f;

    void Start()
    {
        timeSinceLastTurn = Time.time;
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        if ((Time.time - timeSinceLastTurn) > turnDuration) {
            velocity *= -1f;

            timeSinceLastTurn = Time.time;
        }
        controller.Move(velocity * Time.deltaTime, false, false);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            playerHealth.value -= 10;
        }
    }
}
