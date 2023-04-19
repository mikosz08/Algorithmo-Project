using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    private Camera mirrorCamera;

    private void Start()
    {
        mirrorCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 mirrorNormal = transform.up;
        Vector3 mirrorPosition = transform.position;
        Quaternion mirrorRotation = transform.rotation;

        Vector3 reflectedPosition = mirrorPosition - 2 * mirrorNormal * Vector3.Dot(mirrorPosition, mirrorNormal);
        Quaternion reflectedRotation = Quaternion.LookRotation(-mirrorNormal, transform.up) * Quaternion.Euler(0, 180, 0) * mirrorRotation;

        mirrorCamera.transform.position = reflectedPosition;
        mirrorCamera.transform.rotation = reflectedRotation;
    }
}
