using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<EnemyWeight> enemies;
    [SerializeField][Range(3.5f, 15.5f)] private float low_spawn_x_range;
    [SerializeField][Range(3.5f, 15.5f)] private float high_spawn_x_range;
    [SerializeField][Range(1, 10)] private int high_quantity_range;



    private int totalWeight = 0;

    private GameManager gameManager;

    void Start(){
        enemies.ForEach(e => totalWeight += e.weight);
        gameManager = GameManager.Instance;
        StartCoroutine(generateEnemies());
    }

    private IEnumerator generateEnemies(){
        while(true){
            int enemyQuantity = Random.Range(1, high_quantity_range);
            float last_enemy_x = float.MinValue;
            float last_enemy_y = float.MinValue;
            for(int i = 0; i < enemyQuantity; i++){

                GameObject enemy = GetEnemy();

                float next_enemy_x = Random.Range(low_spawn_x_range,high_spawn_x_range);
                float next_enemy_y = Random.Range(-4.5f,4.5f);

                if(next_enemy_x == last_enemy_x){
                    next_enemy_x = Random.Range(low_spawn_x_range,high_spawn_x_range);
                }
                if(next_enemy_y == last_enemy_y){
                    next_enemy_y = Random.Range(-4.5f,4.5f);
                }

                Instantiate(enemy, new Vector3(next_enemy_x, next_enemy_y, 0), Quaternion.identity);
                last_enemy_x = next_enemy_x;
                last_enemy_y = next_enemy_y;
            }

            float defaultTime = 3f;
            float waitTime = defaultTime - (gameManager.game_speed / 1000f);
            yield return new WaitForSeconds(waitTime > 0 ? waitTime : defaultTime);
        }
    }

    private GameObject GetEnemy(){
        int random = Random.Range(0, totalWeight);
        int cumulated = 0;

        foreach(var enemy in enemies){
            cumulated += enemy.weight;
            if(random <= cumulated){
                return enemy.enemy;
            }
        }
        return null;
    }
}
