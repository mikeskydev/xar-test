using UnityEngine;

public class AngularLookAt : MonoBehaviour
{
    public float omega = 1.0f;
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            var direction = target.position - transform.position;

            // Our cone is pointing up, so we need to fix what "up" is
            var targetRotation = Quaternion.FromToRotation(Vector3.up, direction.normalized);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, omega * Time.deltaTime);
        }    
    }
}
