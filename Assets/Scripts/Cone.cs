using System;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Cone : ProceduralMesh
{
    // https://github.com/icosa-foundation/open-blocks/blob/54d6ae33d3820d93e1752318c145d6a2dd9df7fe/Assets/Scripts/model/core/Primitives.cs#L46
    public override ProceduralType type => ProceduralType.Cone;

    private int[] tris => new int[]
    {
        // Faces around point 0.
        0, 11, 5,
        0, 5, 1,
        0, 1, 7,
        0, 7, 10,
        0, 10, 11,

        // Faces adjacent to point 0.
        1, 5, 9,
        5, 11, 4,
        11, 10, 2,
        10, 7, 6,
        7, 1, 8,


        // Faces around point 3.
        3, 9, 4,
        3, 4, 2,
        3, 2, 6,
        3, 6, 8,
        3, 8, 9,

        // Faces adjacent to point 3.
        4, 9, 5,
        2, 4, 11,
        6, 2, 10,
        8, 6, 7,
        9, 8, 1,
    };

    float radius = 1.0f;
    float height = 1.0f;
    int segments = 18;
    const float GOLDEN_RATIO = 1.618033988749895f;

    public Cone(float radius = 1.0f, float height = 1.0f, int segments = 18)
    {
        this.radius = radius;
        this.height = height;
        this.segments = segments;
    }

    public override Mesh Build()
    {
        var mesh = new Mesh();
        mesh.name = "Cone";

        Vector3[] points = new Vector3[segments + 2];
        points[0] = Vector3.up * (height/2);
        points[segments+1] = new Vector3(0, -height/2, 0);

        float angleStep = 2 * Mathf.PI / segments;
        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            points[i + 1] = new Vector3(x, -height/2, z);
        }

        // Triangles
        int[] triangles = new int[segments * 3 * 2];

        // Sides
        for (int i = 0; i < segments; i++)
        {
            int next = (i + 1) % segments;
            triangles[i * 3 + 0] = 0; // tip
            triangles[i * 3 + 1] = next + 1;
            triangles[i * 3 + 2] = i + 1;
        }

        // Base
        int baseIndex = segments * 3;
        int centerVertex = points.Length - 1;
        for (int i = 0; i < segments; i++)
        {
            int next = (i + 1) % segments;
            triangles[baseIndex + i * 3 + 0] = centerVertex;
            triangles[baseIndex + i * 3 + 1] = i + 1;
            triangles[baseIndex + i * 3 + 2] = next + 1;
        }

        // Assign mesh
        mesh.vertices = points;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
