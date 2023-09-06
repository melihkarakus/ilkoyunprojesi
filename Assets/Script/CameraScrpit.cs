
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject targetObject; // Kameran�n takip edece�i nesne
    public Vector3 cameraOffset; // Kameran�n hedef nesneye olan uzakl���
    private Vector3 targetedPosition; // Kameran�n gitmeye �al��t��� pozisyon
    private Vector3 velocity = Vector3.zero; // Kameran�n hareket h�z�

    public float smoothTime = 0.3f; // Kameran�n takip h�z�

    void LateUpdate()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned.");
            return;
        }

        targetedPosition = targetObject.transform.position + cameraOffset; // Kameran�n hedef pozisyonunu hesapla
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime); // Kameray� yumu�ak bir �ekilde hareket ettir
    }
}
