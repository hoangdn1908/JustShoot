using UnityEngine;

public class WeaponIconSpawner : MonoBehaviour
{
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private ObjectPool[] weaponPools;
    [SerializeField] private float timeInterval;
    private Transform target;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeInterval) 
        {
            timer = 0;
            SpawnWeapon();
        }
    }

    private void SetTarget() 
    {
        target = SelectedCharacterSpawner.Instance?.SpawnedCharacter;
    }

    private Vector2 GetPosition() 
    {
        SetTarget();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minDistance, maxDistance);
        return (Vector2)target.position + randomDirection * randomDistance;
    }

    private void SpawnWeapon() 
    {
        int index = Random.Range(0, weaponPools.Length);
        WeaponIconController weaponIconObj = weaponPools[index].GetFromPool().GetComponent<WeaponIconController>();
        weaponIconObj.SetPool(weaponPools[index]);
        weaponIconObj.transform.position = GetPosition();
    }
}
