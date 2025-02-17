using UnityEngine;

public class BounceBumper : MonoBehaviour
{
    [SerializeField] private float bounceMultiplier = 1.5f; 

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 bounceDirection = collision.contacts[0].normal;
            float incomingSpeed = rb.linearVelocity.magnitude; 
            rb.linearVelocity = Vector3.zero; 
            rb.AddForce(bounceDirection * incomingSpeed * bounceMultiplier, ForceMode.Impulse);
        }
    }
}