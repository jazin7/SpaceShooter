using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Stage
    {
        public GameObject[] enemies;
    }

    public GameObject enemyBlack1;
    public GameObject enemyBlue1;
    public GameObject enemyGreen1;
    public GameObject enemyRed1;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

    public TMPro.TextMeshProUGUI stageCounterText;

    private Vector2 spawnPosition = Vector2.zero;
    private List<Stage> stages;
    private int currentStage = 0;
    private int displayStage = 0;

    private void Start()
    {
        stages = new List<Stage>
        {
            new Stage { enemies = new[] { enemyBlack1 } },
            new Stage { enemies = new[] { enemyBlue1 } },
            new Stage { enemies = new[] { enemyBlack1, enemyBlack1 } },
            new Stage { enemies = new[] { enemyGreen1 } },
            new Stage { enemies = new[] { boss1 } },
            new Stage { enemies = new[] { enemyGreen1, enemyGreen1 } },
            new Stage { enemies = new[] { enemyRed1 } },
            new Stage { enemies = new[] { enemyRed1, enemyBlack1 } },
            new Stage { enemies = new[] { enemyBlue1, enemyBlue1, enemyBlue1 } },
            new Stage { enemies = new[] { boss2 } },
            new Stage { enemies = new[] { enemyGreen1, enemyGreen1, enemyGreen1 } },
            new Stage { enemies = new[] { enemyRed1, enemyRed1 } },
            new Stage { enemies = new[] { enemyRed1, enemyRed1, enemyRed1 } },
            new Stage { enemies = new[] { enemyRed1, enemyRed1, enemyRed1, enemyRed1 } },
            new Stage { enemies = new[] { boss3 } }
        };

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            displayStage++;
            stageCounterText.text = "Stage: " + displayStage;

            var enemies = new List<GameObject>();
            Vector2 spawnPosition = new Vector2(4, 0);  // Adjust this value as needed
            Vector2 spawnOffset = new Vector2(1.5f, -1.5f);  // Adjust this value as needed
            for (int i = 0; i < stages[currentStage].enemies.Length; i++)
            {
                var enemyPrefab = stages[currentStage].enemies[i];
                Vector2 enemySpawnPosition = spawnPosition + spawnOffset * i;
                enemies.Add(Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity));
            }

            // Wait until all enemies from this stage are destroyed
            while (enemies.Exists(e => e != null))
            {
                yield return null;
            }

            // Wait for 3 seconds
            yield return new WaitForSeconds(3f);

            currentStage = (currentStage + 1) % stages.Count;
        }
    }
}
