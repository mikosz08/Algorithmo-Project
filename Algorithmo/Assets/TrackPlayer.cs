using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    [SerializeField] private static GameObject trackedObject = null;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private bool shouldTrack = true;

    private void Start()
    {
        if (trackedObject == null)
            trackedObject = FindAnyObjectByType<CameraMovement>().gameObject;
    }

    private void Update()
    {
        if (shouldTrack)
        {
            // Get the direction from this object to the tracked object
            Vector3 direction = trackedObject.transform.position - transform.position;

            // Create a rotation that points towards the tracked object
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Interpolate between the current rotation and the target rotation using Slerp
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
