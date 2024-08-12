using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    bool isSpawning = false;
    private void Update()
    {
        if (!isSpawning)
        {
            StartCoroutine(RockSpawning());
        }
    }

    IEnumerator RockSpawning()
    {
        isSpawning = true;
        yield return new WaitForSeconds(2f);
        ObjectPooling.Instance.SpawnFromPool("rock1", new Vector3(0, 15, 0), Quaternion.identity);
        isSpawning = false;
    }
}
