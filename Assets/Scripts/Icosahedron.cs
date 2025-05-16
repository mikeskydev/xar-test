using System;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Icosahedron : ProceduralMesh
{
    // https://github.com/icosa-foundation/open-blocks/blob/54d6ae33d3820d93e1752318c145d6a2dd9df7fe/Assets/Scripts/model/core/Primitives.cs#L46
    public override ProceduralType type => ProceduralType.Icosahedron;

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

    float scale = 1.0f;
    const float GOLDEN_RATIO = 1.618033988749895f;

    public Icosahedron(float scale = 1.0f)
    {
        this.scale = scale;
    }

    public override Mesh Build()
    {
        var mesh = new Mesh();
        mesh.name = "Icosahedron";

        Vector3[] points = {
            new Vector3(-1f, GOLDEN_RATIO, 0) * scale,
            new Vector3(1f, GOLDEN_RATIO, 0) * scale,
            new Vector3(-1f, -GOLDEN_RATIO, 0) * scale,
            new Vector3(1f, -GOLDEN_RATIO, 0) * scale,

            new Vector3(0, -1f, GOLDEN_RATIO) * scale,
            new Vector3(0, 1f, GOLDEN_RATIO) * scale,
            new Vector3(0, -1f, -GOLDEN_RATIO) * scale,
            new Vector3(0, 1f, -GOLDEN_RATIO) * scale,

            new Vector3(GOLDEN_RATIO, 0, -1f) * scale,
            new Vector3(GOLDEN_RATIO, 0, 1f) * scale,
            new Vector3(-GOLDEN_RATIO, 0, -1f) * scale,
            new Vector3(-GOLDEN_RATIO, 0, 1f) * scale
        };

        mesh.vertices = points;
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        return mesh;
    }
}
