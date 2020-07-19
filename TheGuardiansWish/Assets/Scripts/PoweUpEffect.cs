using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpEffect : MonoBehaviour
{
    public int typeOfEffect;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(typeOfEffect == 0)
            {
                characterController.moveSpeed += 0.5f;
                Debug.Log("Character bewegt sich nun schneller");
            }
            else if (typeOfEffect == 1)
            {
                projectile.GetComponent<shooting>().speed += 1f;
                Debug.Log("Projektile fliegen nun schneller");
            }
            else if (typeOfEffect == 2)
            {
                projectile.GetComponent<shooting>().rate += 0.5f;
                Debug.Log("Die Feuerrate hat sich erhöht");
            }
            Destroy(gameObject);
        }
    }
}
