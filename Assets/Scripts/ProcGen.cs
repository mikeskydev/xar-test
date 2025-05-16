using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class ProcGen : MonoBehaviour
{
    [SerializeField] ProceduralMesh.ProceduralType ModelType;
    [SerializeField] float scale = 1;

    void Awake()
    {
        ProceduralMesh proc = null;
        switch (ModelType)
        {
            case ProceduralMesh.ProceduralType.Icosahedron:
                proc = new Icosahedron(scale);
                break;
            case ProceduralMesh.ProceduralType.Cone:
                proc = new Cone(scale);
                break;
        }

        if (proc != null)
        {
            GetComponent<MeshFilter>().mesh = proc.Build();
        }
    }
}
