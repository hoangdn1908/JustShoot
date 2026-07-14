using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] enemySpawners;
    [SerializeField] private float timeInterval;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval) 
        {
            SpawnEnemyInRandomSpawner();
            timer = 0;
        }
    }

    private void SpawnEnemyInRandomSpawner() 
    {
        int index = Random.Range(0, enemySpawners.Length);
        enemySpawners[index].Spawn();
    }
}
