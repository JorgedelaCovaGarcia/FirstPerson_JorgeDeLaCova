using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StarCorutine(SpawnerarEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnearEnemigos()
    {
        while(true)
        {
            Instantiate(enemigoPrefab, puntoSpawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
