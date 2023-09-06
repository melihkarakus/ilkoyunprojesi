
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject targetObject; // Kameranýn takip edeceði nesne
    public Vector3 cameraOffset; // Kameranýn hedef nesneye olan uzaklýðý
    private Vector3 targetedPosition; // Kameranýn gitmeye çalýþtýðý pozisyon
    private Vector3 velocity = Vector3.zero; // Kameranýn hareket hýzý

    public float smoothTime = 0.3f; // Kameranýn takip hýzý

    void LateUpdate()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned.");
            return;
        }

        targetedPosition = targetObject.transform.position + cameraOffset; // Kameranýn hedef pozisyonunu hesapla
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime); // Kamerayý yumuþak bir þekilde hareket ettir
    }
}
