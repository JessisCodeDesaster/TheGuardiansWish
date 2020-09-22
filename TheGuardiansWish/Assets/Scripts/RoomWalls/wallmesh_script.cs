using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmesh_script : MonoBehaviour
{
    static Vector3[] vertices;
    static Vector2[] uv;
    static int[] triangles;

    static int v;
    static int t;

    public GameObject walls;
    public static Mesh wallMesh;

    public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        vertices = new Vector3[0];
        triangles = new int[0];
        uv = new Vector2[0];

        wallMesh = new Mesh();
        walls.AddComponent<MeshFilter>();
        walls.AddComponent<MeshRenderer>();
        wallMesh = walls.GetComponent<MeshFilter>().mesh;
        walls.AddComponent<MeshCollider>();

        v = 0;
        t = 0;
    }

    public static void AddWall(float x1, float x2, float y1, float y2, float z1, float z2, Vector3 pos)
    {
        System.Array.Resize(ref vertices, vertices.Length + 24);
        System.Array.Resize(ref triangles, triangles.Length + 84);
        System.Array.Resize(ref uv, uv.Length + 24);

        vertices[v] =       new Vector3(x2, y2, z1) + pos;
        vertices[v + 1] =   new Vector3(x1, y2, z1) + pos;
        vertices[v + 2] =   new Vector3(x1, y1, z1) + pos;
        vertices[v + 3] =   new Vector3(x2, y1, z1) + pos;

        triangles[t] = v + 1;
        triangles[t + 1] = v;
        triangles[t + 2] = v + 2;

        triangles[t + 3] = v;
        triangles[t + 4] = v + 3;
        triangles[t + 5] = v + 2;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;

        vertices[v] = new Vector3(x1, y2, z2) + pos;
        vertices[v + 1] = new Vector3(x1, y1, z2) + pos;
        vertices[v + 2] = new Vector3(x1, y1, z1) + pos;
        vertices[v + 3] = new Vector3(x1, y2, z1) + pos;

        triangles[t] = v;
        triangles[t + 1] = v + 2;
        triangles[t + 2] = v + 1;

        triangles[t + 3] = v;
        triangles[t + 4] = v + 3;
        triangles[t + 5] = v + 2;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;

        vertices[v] = new Vector3(x2, y2, z2) + pos;
        vertices[v + 1] = new Vector3(x2, y1, z2) + pos;
        vertices[v + 2] = new Vector3(x1, y1, z2) + pos;
        vertices[v + 3] = new Vector3(x1, y2, z2) + pos;

        triangles[t] = v;
        triangles[t + 1] = v + 2;
        triangles[t + 2] = v + 1;

        triangles[t + 3] = v;
        triangles[t + 4] = v + 3;
        triangles[t + 5] = v + 2;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;

        vertices[v] = new Vector3(x2, y2, z1) + pos;
        vertices[v + 1] = new Vector3(x2, y1, z1) + pos;
        vertices[v + 2] = new Vector3(x2, y1, z2) + pos;
        vertices[v + 3] = new Vector3(x2, y2, z2) + pos;

        triangles[t] = v;
        triangles[t + 1] = v + 2;
        triangles[t + 2] = v + 1;

        triangles[t + 3] = v;
        triangles[t + 4] = v + 3;
        triangles[t + 5] = v + 2;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;

        vertices[v] = new Vector3(x2, y2, z1) + pos;
        vertices[v + 1] = new Vector3(x2, y2, z2) + pos;
        vertices[v + 2] = new Vector3(x1, y2, z1) + pos;
        vertices[v + 3] = new Vector3(x1, y2, z2) + pos;

        triangles[t] = v;
        triangles[t + 1] = v + 2;
        triangles[t + 2] = v + 1;

        triangles[t + 3] = v + 1;
        triangles[t + 4] = v + 2;
        triangles[t + 5] = v + 3;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;

        vertices[v] = new Vector3(x2, y1, z1) + pos;
        vertices[v + 1] = new Vector3(x2, y1, z2) + pos;
        vertices[v + 2] = new Vector3(x1, y1, z1) + pos;
        vertices[v + 3] = new Vector3(x1, y1, z2) + pos;

        triangles[t] = v;
        triangles[t + 1] = v + 2;
        triangles[t + 2] = v + 1;

        triangles[t + 3] = v + 1;
        triangles[t + 4] = v + 2;
        triangles[t + 5] = v + 3;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;
    }

    public static void ShowWalls(GameObject walls)
    {
        wallMesh.Clear();

        wallMesh.vertices = vertices;
        wallMesh.triangles = triangles;
        wallMesh.uv = uv;
        wallMesh.RecalculateNormals();
        Renderer rend = walls.GetComponent<Renderer>();
    }
}
