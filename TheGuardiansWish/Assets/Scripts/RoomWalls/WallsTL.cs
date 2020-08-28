using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsTL : MonoBehaviour
{
    public GameObject walls;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;

        //top
        wallmesh_script.AddWall(-15, 15, 0, 10, 14.25f, 15.75f, pos);

        //bottom
        wallmesh_script.AddWall(-3, -15, 0, 10, -14.25f, -15.75f, pos);
        wallmesh_script.AddWall(15, 3, 0, 10, -14.25f, -15.75f, pos);

        //left
        wallmesh_script.AddWall(-15.75f, -14.25f, 0, 10, -15, 15, pos);

        //right
        wallmesh_script.AddWall(14.25f, 15.75f, 0, 10, 3, 15, pos);
        wallmesh_script.AddWall(14.25f, 15.75f, 0, 10, -15, -3, pos);

        wallmesh_script.ShowWalls(walls);
    }
}
