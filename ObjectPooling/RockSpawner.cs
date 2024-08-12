using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(RockSpawning());
    }

    IEnumerator RockSpawning()
    {
        yield return new WaitForSeconds(2f);
        ObjectPooling.Instance.SpawnFromPool("rock1", new Vector3(0, 15, 0), Quaternion.identity);
    }
}
