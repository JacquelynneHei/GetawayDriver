using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Player Hit Me");
            GameManager.instance.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
