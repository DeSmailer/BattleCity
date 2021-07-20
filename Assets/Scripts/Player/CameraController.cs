using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float bottomLimit;
    [SerializeField]
    private float upperLimit;
    [SerializeField]
    private float smooth;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, transform.position, Time.deltaTime * smooth);
        //границы для камеры
        mainCamera.transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            -10
            );
    }
}
