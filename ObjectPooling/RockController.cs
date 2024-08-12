using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour, IPoolingObject
{
    GameObject player;
    CharacterStats playerHealth;

    public float sideForce = 5f;  

    public void OnObjectSpawn()
    {
        float zForce = Random.Range(-sideForce, sideForce);

        GetComponent<Rigidbody>().velocity = new Vector3(0, -10, zForce);

        player = PlayerManager.instance.player;
        playerHealth = player.GetComponent<CharacterStats>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(5);
        }
    }
}
