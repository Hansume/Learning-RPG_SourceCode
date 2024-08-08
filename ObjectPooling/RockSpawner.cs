using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    private void Update()
    {
       ObjectPooling.Instance.SpawnFromPool("rock1", new Vector3(0,15,0), Quaternion.identity);
    }
}
