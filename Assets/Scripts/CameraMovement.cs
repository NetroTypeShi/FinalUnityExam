using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;      // Asigna el jugador desde el inspector
    public Transform coin;        // Asigna la moneda desde el inspector
    public float smoothSpeed = 0.1f;
    public float minZoom = 5f;
    public float zoomLimiter = 5f;
    float distance;
    float desiredZoom;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player == null || coin == null) return;

        // Calcular la distancia entre jugador y moneda
        distance = Vector2.Distance(player.position, coin.position);

        // Ajustar el zoom solo con mínimo, sin máximo
        desiredZoom = Mathf.Max(distance / zoomLimiter, minZoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, desiredZoom, smoothSpeed);
    }
}
