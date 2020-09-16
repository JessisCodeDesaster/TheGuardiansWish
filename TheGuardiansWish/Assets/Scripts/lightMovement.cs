using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMovement : MonoBehaviour
{
    float posy;
    bool up;

    // Start is called before the first frame update
    void Start()
    {
        posy = 3;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (posy <= 10f && up == true)
        {
            transform.position += new Vector3(0, 0.03f, 0);
            posy += 0.03f;
            if (posy >= 10f)
            {
                up = false;
            }
        }
        if (posy >= 3f && up == false)
        {
            transform.position += new Vector3(0, -0.03f, 0);
            posy -= 0.03f;
            if (posy <= 3f)
            {
                up = true;
            }
        }
     }
}
