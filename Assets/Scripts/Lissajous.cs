using UnityEngine;

public class Lissajous : MonoBehaviour
{
    public float X = 1f;
    public float Y = 2f;
    public float Z = 3f;

    public float alpha = 3f;
    public float beta = 2f;
    public float gamma = 1f;
    public float delta = Mathf.PI / 2; // nice symmetry per wikipedia page
    public float speed = 1f;

    private float time;

    void Update()
    {
        time += Time.deltaTime * speed;

        float x = X * Mathf.Sin(alpha * time + delta);
        float y = Y * Mathf.Sin(beta * time);
        float z = Z * Mathf.Sin(gamma * time);

        transform.position = new Vector3(x, y, z);
    }
}
