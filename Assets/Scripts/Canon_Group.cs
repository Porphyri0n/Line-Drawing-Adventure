using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Group : MonoBehaviour
    
{

    [SerializeField] public List<Fruit> fruitList;
    [SerializeField] private List<Canon> canonList;
    [SerializeField, Range(2f, 0.1f)] private float spawnRate = 1f;
    public int spawnCoinCounter;
    public int spawnTimerCounter;
    public static Canon_Group Instance;
    void Start()
    {
        Instance= this;
        StartCoroutine(SpawnFruitsWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        //canonList[0].GetComponent<Canon>().spawnFruit();
    }
    private IEnumerator SpawnFruitsWithDelay()
    {
        while(true)
        {
            spawnCoinCounter++;
            spawnTimerCounter++;
            yield return new WaitForSeconds(spawnRate);
            canonList[Random.Range(0,canonList.Count)].GetComponent<Canon>().spawnFruit();
            Debug.Log(spawnCoinCounter);
            Debug.Log(spawnTimerCounter);

        }
    }
}
