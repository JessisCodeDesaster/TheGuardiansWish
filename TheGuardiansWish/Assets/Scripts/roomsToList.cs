using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomsToList : MonoBehaviour { 

    private roomTemplates templates;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

