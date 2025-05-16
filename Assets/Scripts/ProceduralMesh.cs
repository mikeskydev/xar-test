using UnityEngine;

public abstract class ProceduralMesh
{
    public enum ProceduralType
    {
        Icosahedron,
        Cone,
    }

    public abstract ProceduralType type { get; }
    public abstract Mesh Build();
}
