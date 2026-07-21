using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool[] enemyPools;
    [SerializeField] private Transform spawnPos;

    public void Spawn()
    {
        Transform target = SelectedCharacterSpawner.Instance?.SpawnedCharacter;
        if (target == null) return;
        int index = Random.Range(0, enemyPools.Length);
        EnemyController enemyController = enemyPools[index].GetFromPool().GetComponent<EnemyController>();
        enemyController.PrepareForSpawn(enemyPools[index], target);
        enemyController.transform.position = spawnPos.position;
    }
}
