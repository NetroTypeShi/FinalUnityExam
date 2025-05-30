using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Vector2 teleportMin = new Vector2(-8, -4);
    [SerializeField] private Vector2 teleportMax = new Vector2(8, 4);
    PlayerMovement playerMovement;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            PlayerMovement playerMovement = trigger.GetComponent<PlayerMovement>();
            Debug.Log("¡Moneda recogida!");
            // Teletransporta la moneda a una nueva posición aleatoria
            x = Random.Range(teleportMin.x, teleportMax.x);
            y = Random.Range(teleportMin.y, teleportMax.y);
            transform.position = new Vector3(x, y, transform.position.z);
            playerMovement.score += 1;
            if (GameEvents.Instance != null)
            {
                GameEvents.Instance.CoinCollected();
            }
        }
    }
}
