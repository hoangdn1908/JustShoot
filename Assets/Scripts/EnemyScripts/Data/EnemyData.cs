using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float moveSpeed;
    public float maxHealth;
}
