using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool[] enemyPools;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform target; 

    public void Spawn() 
    {
        int index = Random.Range(0, enemyPools.Length);
        EnemyController enemyController = enemyPools[index].GetFromPool().GetComponent<EnemyController>();
        enemyController.PrepareForSpawn(enemyPools[index], target);
        enemyController.transform.position = spawnPos.position;
    }
}
