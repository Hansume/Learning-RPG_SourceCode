using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour, IPoolingObject
{
    GameObject player;
    CharacterStats playerHealth;

    public float upForce = 2f;
    public float sideForce = .2f;  

    public void OnObjectSpawn()
    {
        GetComponent<Rigidbody>().velocity -= new Vector3(0, 10, 0);

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
