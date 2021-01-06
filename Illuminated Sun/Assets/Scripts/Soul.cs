using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    //ontriggerenter
    //giveplayer coin
    //destroy object
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.AddSouls();
            }

            Destroy(this.gameObject);
        }
    }

}
