using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap_mesh : MonoBehaviour
{
    static Vector3[] vertices;
    static Vector2[] uv;
    static int[] triangles;

    static int v;
    static int t;

    GameObject map_room;
    public static Mesh map_room_mesh;
    public Material inactiveRoom;
    public Material activeRoom;
    public Renderer rend;

    void Start()
    {
        map_room = new GameObject();
        vertices = new Vector3[0];
        triangles = new int[0];
        uv = new Vector2[0];

        map_room_mesh = new Mesh();
        map_room.AddComponent<MeshFilter>();
        map_room.AddComponent<MeshRenderer>();
        map_room_mesh = map_room.GetComponent<MeshFilter>().mesh;

        v = 0;
        t = 0;

        addMesh();
        ShowMapRooms(map_room);
        Debug.Log("TestTestTest");
    }

    void addMesh()
    {
        System.Array.Resize(ref vertices, vertices.Length + 4);
        System.Array.Resize(ref triangles, triangles.Length + 6);
        System.Array.Resize(ref uv, uv.Length + 4);

        vertices[v] = new Vector3(15, 15, 15) + transform.position;
        vertices[v + 1] = new Vector3(15, 15, -15) + transform.position;
        vertices[v + 2] = new Vector3(-15, 15, 15) + transform.position;
        vertices[v + 3] = new Vector3(-15, 15, -15) + transform.position;

        triangles[t] = v;
        triangles[t + 1] = v + 1;
        triangles[t + 2] = v + 2;

        triangles[t + 3] = v + 1;
        triangles[t + 4] = v + 3;
        triangles[t + 5] = v + 2;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;
    }

    public static void ShowMapRooms(GameObject map_room)
    {
        map_room_mesh.Clear();

        map_room_mesh.vertices = vertices;
        map_room_mesh.triangles = triangles;
        map_room_mesh.uv = uv;
        map_room_mesh.RecalculateNormals();
        Renderer rend = map_room.GetComponent<Renderer>();

        rend.material.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            map_room.GetComponent<Renderer>().material = inactiveRoom;
            rend.material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            Debug.Log("Player left");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            map_room.GetComponent<Renderer>().material = activeRoom;
            Debug.Log("Player entered");
        }
    }

}
