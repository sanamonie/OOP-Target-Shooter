using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<PoolableObject> Targets;
    private List<ObjectPooler> targetPools = new List<ObjectPooler>();
    public ParticleSpawner pSpawner;

    int medium = 1;
    int hard = 1;

    Coroutine waveRoutine;

    // Start is called before the first frame update
    void Start()
    {
        foreach (PoolableObject tValue in Targets)
        {
            ObjectPooler tempTargetPool = ObjectPooler.CreateInstance(tValue, 10);
            targetPools.Add(tempTargetPool);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnSingle(int targetIndex) {
        var setupTarget = targetPools[targetIndex].GetObject();
        Target targetScript = setupTarget.GetComponent<Target>();

        Vector3 startPos = new Vector3(-8.5f, Random.Range(-4f, 5f), 19);
        setupTarget.transform.position = startPos;

        Vector3 tempDirrection = ((new Vector3(27.5f, Random.Range(-4f, 5), 19)) - startPos).normalized;
        targetScript.dirrection = tempDirrection;

        targetScript.startParticle += pSpawner.spawnParticle;

    }

    public void SpawnWave(int waveNumber) {
        int[] currentWave = new int[waveNumber * 5];
        for (int i = 0; i < currentWave.Length; i++) {
            currentWave[i] = 0;
        }
        List<int> usedIndexes = new List<int>();
        //replaces defualt targets with medium 
        //adds used index to usedIndexes to no overlaps are done on added blocks
        for (int i = 0; i < medium * waveNumber;i++) {
            int tempIndex = RandomNotInList(usedIndexes, waveNumber);
           // Debug.Log(tempIndex + " is medium");
            usedIndexes.Add(tempIndex);
            currentWave[tempIndex] = 1; 
        }
        for (int i = 0; i < hard * waveNumber; i++)
        {
            int tempIndex = RandomNotInList(usedIndexes, waveNumber);
           // Debug.Log(tempIndex + " is hard");
            usedIndexes.Add(tempIndex);
            currentWave[tempIndex] = 2;
        }
        if (waveRoutine != null) {
            StopCoroutine(waveRoutine);
        }
        waveRoutine = StartCoroutine(Wave(currentWave));

    }

    int RandomNotInList(List<int> usedIndexes,int waveNumber) {
        int tempInt = Random.Range(0, (waveNumber * 5) - 1);
        foreach (int value in usedIndexes)
        {
            if (tempInt == value)
            {
               Debug.Log("recursion ran");
               tempInt = RandomNotInList(usedIndexes, waveNumber);
            }
        }
        return tempInt;
    }

    IEnumerator Wave(int[] waveToSpawn) { 
        WaitForSeconds wait = new WaitForSeconds(1);

        for (int i = 0; i < waveToSpawn.Length; i++) {
            spawnSingle(waveToSpawn[i]);
            yield return wait;
        }
        Debug.Log("wave end");
        yield return new WaitForSeconds(5);
        GameManager.Instance.waveComplete = true;
        GameManager.Instance.waveNumber++;
    }

    public void stopSpawn() {
        if (waveRoutine != null) {
            StopCoroutine(waveRoutine);
        }
        
    }
    //spawn single
    //spawn position(rand), end pos(rand), dirrection 
    //spawn wave
    //amount to spawn, 
}
