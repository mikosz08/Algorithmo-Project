using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Vector3 positionOffset = Vector3.zero;
    private GameObject target = null;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        FollowPlayer();
        Rotate();
    }

    private float rotateH = 0.0f;
    private float rotateV = 0.0f;

    private void Rotate()
    {
        rotateH += Input.GetAxis("Mouse X");
        rotateV -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(rotateV, rotateH, 0.0f);

        target.transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }

    private void FollowPlayer()
    {
        transform.position = target.transform.position + positionOffset;
    }
}
