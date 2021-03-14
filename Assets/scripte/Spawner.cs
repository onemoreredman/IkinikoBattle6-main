using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }
    /// <summary>
    /// 敵出現のコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnLoop() {

        while (true) {
            var distanceVector = new Vector3(10, 0);

            var spawnPositionFromPlayer = Quaternion.Euler(0, Random.Range(0, 360f), 0) * distanceVector;

            var spawnPosition = playerStatus.transform.position + spawnPositionFromPlayer;

            NavMeshHit navMeshHit;

            if(NavMesh.SamplePosition(spawnPosition,out navMeshHit, 10, NavMesh.AllAreas))
            {
                Instantiate(enemyPrefab, navMeshHit.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(10);

            if (playerStatus.Life <= 0) {
                break;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
