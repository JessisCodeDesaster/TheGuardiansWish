using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoweUpEffect : MonoBehaviour
{
    public int typeOfEffect;
    public GameObject projectile;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(typeOfEffect == 0)
            {
                characterController.moveSpeed += 0.5f;
                //characterController.helper(0);
                Debug.Log("Character bewegt sich nun schneller");
            }
            else if (typeOfEffect == 1)
            {

                projectile.GetComponent<shooting>().speed += 1f;
                //characterController.helper(1);
                Debug.Log("Projektile fliegen nun schneller");
            }
            else if (typeOfEffect == 2)
            {
                projectile.GetComponent<shooting>().rate += 0.5f;
                //characterController.helper(2);
                Debug.Log("Die Feuerrate hat sich erhöht");
            }
            Destroy(gameObject);
        }
    }
}
