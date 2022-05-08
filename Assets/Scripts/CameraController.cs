using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    Transform playerBody;

    Vector3 lookEuler = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        SetCameraAngle();
    }

    private void SetCameraAngle() 
    {
        float mouseMoveY = Input.GetAxis("Mouse Y");
        float mouseMoveX = Input.GetAxis("Mouse X");

        playerBody.Rotate(Vector3.up * mouseMoveX);

        lookEuler = lookEuler + new Vector3(-mouseMoveY, 0, 0);
        lookEuler = new Vector3(Mathf.Clamp(lookEuler.x,-90,90), 0, 0);

        transform.localRotation = Quaternion.Euler(lookEuler);
    }
}
