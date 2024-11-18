using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerialeizeField] private GameObject enemigoPrefab;
    [SerialeizeField] private Transform[] puntosSpawn;
    [SerialeizeField] private int numeroNiveles;
    [SerialeizeField] private int rondasPorNivel;
    [SerialeizeField] private int spawnPorRonda;
    [SerialeizeField] private float esperaEntreSpawns;
    [SerialeizeField] private float esperaEntreRondas;
    [SerialeizeField] private float esperaEntreNiveles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawnear()
    {
        for (int i = 0; i < numeroNiveles; i++)
        {
            for (int j = 0; j < rondasPorNivel; j++)
            {
                for (int k = 0; k < spawnPorRonda; k++)
                {
                    int indiceAleatorio = Random.Range(0, puntosSpawn.Length);
                    Instantiate(enemigoPrefab, puntosSpawn[indiceAleatorio].position, Queaternion.identity);

                    yield return new WaitForSeconds(esperaEntreSpawns);
                }

                yield return new WaitForSeconds(esperaEntreRondas);
            }

            yield return new WaitForSeconds(esperaEntreNiveles);
        }
    }
}
