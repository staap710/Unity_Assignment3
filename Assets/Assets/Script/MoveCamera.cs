using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform targetToLookAt;
    public Vector3 offset;
    public Transform orientation;
    public float cameraRotateSpeed;
    float XRotation;
    float YRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToLookAt.position + offset;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraRotateSpeed;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraRotateSpeed;
        YRotation += mouseX;
        XRotation -= mousey;
        XRotation = Mathf.Clamp(XRotation, -90, 90);
        //rotate camera and orientation
        transform.rotation = Quaternion.Euler(XRotation, YRotation, 0);
        orientation.rotation = Quaternion.Euler(0, YRotation, 0);
    }
}
