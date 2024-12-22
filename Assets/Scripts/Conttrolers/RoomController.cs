using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject enemyPrefab;
        public int enemyCount;
        public int maxEnemiesPerWave;
    }

    private int enemyCountAux = 0;
    public List<EnemyType> enemyTypes = new List<EnemyType>();
    public List<Transform> spawnPoints = new List<Transform>(); 
    public int waveCount = 3;

    public int remainingEnemies; 

    public int currentWave = 0;

    public bool startWave;

    void Start()
    {
        if (startWave)
        {
            SpawnWave();
        }
    }

    private void Update()
    {
        if (startWave)
        {
            if (remainingEnemies == 0 && currentWave < waveCount)
            {
                currentWave++;
                SpawnWave();
            }
        }
    }

    void SpawnWave()
    {
        Debug.Log("Iniciando onda " + (currentWave + 1));

        if (currentWave < waveCount)
        {
            int totalEnemiesInWave = 0;

            foreach (EnemyType enemyType in enemyTypes)
            {
                int enemiesToSpawn = Mathf.Min(enemyType.maxEnemiesPerWave, enemyType.enemyCount);
                totalEnemiesInWave += enemiesToSpawn;
                enemyCountAux = enemyType.enemyCount;

                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    Vector3 spawnPosition = GetRandomSpawnPosition();

                    Instantiate(enemyType.enemyPrefab, spawnPosition, Quaternion.identity);
                    enemyCountAux--;

                    remainingEnemies++; 
                }
            }

            Debug.Log("Aguardando final da onda " + currentWave);
        }
        else
        {
            Debug.Log("Fim das ondas");
        }
    }

    public void EnemyDefeated()
    {
        if(remainingEnemies > 0)
        {
            remainingEnemies--;
        } 

        if (remainingEnemies == 0 && currentWave >= waveCount)
        {
            
            Debug.Log("Todos os inimigos foram derrotados!");
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogError("Lista de pontos de spawn está vazia!");
            return Vector3.zero;
        }

        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex].position;
    }
}
