using UnityEngine;

public class FloatingWeapon : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private float speed;
    [SerializeField] private bool randomizePhase;
    private Vector3 startPos;
    private float phase;

    private void Awake()
    {
        SetPhase();
    }

    private void Update()
    {
        Floating();
    }

    public void SetSpawnPosition(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
        startPos = spawnPosition;
    }

    private void SetPhase() 
    {
        if (randomizePhase) 
        {
            phase = Random.Range(0f, Mathf.PI * 2f);
        }
    }

    private void Floating() 
    {
        float offSetY = Mathf.Sin(Time.time * speed + phase) * height;
        transform.localPosition = startPos + Vector3.up * offSetY;
    }
}
