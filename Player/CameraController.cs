using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float pitch = 2f;
    private float zoom = 10f;

    private void LateUpdate()
    {
        transform.position = player.position - offset * zoom;
        transform.LookAt(player.position + Vector3.up * pitch);
    }
}
