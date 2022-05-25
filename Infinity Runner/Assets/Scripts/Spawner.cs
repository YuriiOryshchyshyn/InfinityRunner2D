using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private float _timeBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemyPrefab.gameObject);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject result))
            {
                _elapsedTime = 0;

                int spawnPosition = Random.Range(0, _spawnPositions.Length);

                result.SetActive(true);
                result.transform.position = _spawnPositions[spawnPosition].position;
            }
        }
    }
}
