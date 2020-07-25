using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public int openSide;
    // 1 -> brauche tür unten
    // 2 -> brauche tür oben
    // 3 -> brauche tür links
    // 4 -> brauche tür rechts

    private roomTemplates templates;
    private int random;
    private bool spawned = false;

    //für die wände---------------------------------------
    /*public GameObject dungeonwalls;
    Mesh wallmesh;

    List<Vector3> vertices;
    List<Vector2> uv;
    List<int> triangles;

    int v;
    int t;
    int height;
    int width;*/
    //-----------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        //verzögert, da sonst buggy
        Invoke("spawnRoom", 0.1f);

        /*vertices = new List<Vector3>();
        triangles = new List<int>();
        uv = new List<Vector2>();

        dungeonwalls = new GameObject();
        wallmesh = new Mesh();
        dungeonwalls.AddComponent<MeshFilter>();
        dungeonwalls.AddComponent<MeshRenderer>();
        wallmesh = dungeonwalls.GetComponent<MeshFilter>().mesh;*/
    }

    // Update is called once per frame
    void spawnRoom()
    {
        if(spawned == false)
        {
            if (openSide == 1)
            {
                random = Random.Range(0, templates.bottom.Length);
                Instantiate(templates.bottom[random], transform.position, templates.bottom[random].transform.rotation);
                /*if(random == 0)
                {
                    spawnwalls(true, false, true, false, transform.position);
                } else if (random == 1)
                {
                    spawnwalls(true, false, false, false, transform.position);
                } else if (random == 2)
                {
                    spawnwalls(true, false, false, true, transform.position);
                } else if (random == 3)
                {
                    spawnwalls(true, true, false, false, transform.position);
                }*/
            }
            else if (openSide == 2)
            {
                random = Random.Range(0, templates.top.Length);
                Instantiate(templates.top[random], transform.position, templates.top[random].transform.rotation);
            }
            else if (openSide == 3)
            {
                random = Random.Range(0, templates.left.Length);
                Instantiate(templates.left[random], transform.position, templates.left[random].transform.rotation);
            }
            else if (openSide == 4)
            {
                random = Random.Range(0, templates.right.Length);
                Instantiate(templates.right[random], transform.position, templates.right[random].transform.rotation);
            }
            spawned = true;
        }
    }

    //Sorgt dafür, dass nicht mehrere Räume übereinander sind
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Spawn") && other.GetComponent<roomSpawn>().spawned == true)
        {
            Destroy(gameObject);
        }
    }

    /*public void spawnwalls(bool unten, bool oben, bool links, bool rechts, Vector3 position)
    {
        float x = position.x;
        float z = position.z;

        if (unten == true)
        {
            //createCube(x+10, z+10);
            //createCube(x-10, z+11);
        } else
        {
            createCube(x+10, z+10, x-10, z+11);
        }
    }

    void createCube(float posx1, float posz1, float posx2, float posz2)
    {
        var y = 15;

        vertices[v] = new Vector3(posx2, y, posz1);
        vertices[v + 1] = new Vector3(posx2, 0, posz1);
        vertices[v + 2] = new Vector3(posx2, 0, posz2);
        vertices[v + 3] = new Vector3(posx2, y, posz2);

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

        vertices[v] = new Vector3(posx1, y, posz1);
        vertices[v + 1] = new Vector3(posx1, 0, posz1);
        vertices[v + 2] = new Vector3(posx1, 0, posz2);
        vertices[v + 3] = new Vector3(posx1, y, posz2);

        triangles[t] = v;
        triangles[t + 1] = v + 1;
        triangles[t + 2] = v + 2;

        triangles[t + 3] = v;
        triangles[t + 4] = v + 2;
        triangles[t + 5] = v + 3;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;

        vertices[v] = new Vector3(posx1, y, posz2);
        vertices[v + 1] = new Vector3(posx1, 0, posz2);
        vertices[v + 2] = new Vector3(posx1 - 1, 0, posz2);
        vertices[v + 3] = new Vector3(posx1 - 1, y, posz2);

        triangles[t] = v;
        triangles[t + 1] = v + 1;
        triangles[t + 2] = v + 2;

        triangles[t + 3] = v;
        triangles[t + 4] = v + 2;
        triangles[t + 5] = v + 3;

        uv[v] = new Vector2(v, v);
        uv[v + 1] = new Vector2(v, v + 1);
        uv[v + 2] = new Vector2(v + 1, v + 1);
        uv[v + 3] = new Vector2(v + 1, v);

        v += 4;
        t += 6;

        vertices[v] = new Vector3(posx1, y, posz1);
        vertices[v + 1] = new Vector3(posx1, 0, posz1);
        vertices[v + 2] = new Vector3(posx2, 0, posz1);
        vertices[v + 3] = new Vector3(posx2, y, posz1);

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

        vertices[v] = new Vector3(posx1, y, posz2);
        vertices[v + 1] = new Vector3(posx1, y, posz1);
        vertices[v + 2] = new Vector3(posx2, y, posz2);
        vertices[v + 3] = new Vector3(posx2, y, posz1);

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

    void DrawCity()
    {
        wallmesh.Clear();

        Vector3[] verts = vertices.ToArray();
        wallmesh.vertices = verts;

        int[] tri = triangles.ToArray();
        wallmesh.triangles = tri;

        Vector2[] uvs = uv.ToArray();
        wallmesh.uv = uvs;

        wallmesh.RecalculateNormals();
        Renderer rend = dungeonwalls.GetComponent<Renderer>();
        //rend.material = cityMaterial;
    }*/
}
