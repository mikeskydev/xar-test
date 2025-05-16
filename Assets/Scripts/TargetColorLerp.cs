using UnityEngine;

public class TargetColorLerp : MonoBehaviour
{
    public Transform target;
    public MeshRenderer targetMaterial;

    [SerializeField] float dot;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            var forward = transform.up.normalized;
            var toTarget = (target.position - transform.position).normalized;
            dot = Vector3.Dot(forward, toTarget);

            if (targetMaterial) {
                targetMaterial.material.SetFloat("_Lerp", dot);
            }
        }
    }
}
