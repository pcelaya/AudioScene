using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    void Update()
    {
        // Rotate around the Z axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}