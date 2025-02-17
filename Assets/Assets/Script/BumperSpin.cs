using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f; // Rotation speed in degrees per second

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime,0 , 0);
    }
}
