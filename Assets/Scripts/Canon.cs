using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    private enum CannonType
    {
        upperCannon,
        leftSideCannon,
        rightSideCannon,
        leftUpperCrossCannon,
        rightUpperCrossCannon,
        leftLowerCannon,
        rightLowerCannon,
    }
    private int randomTimerSpawnRate;
    private int randomCoinSpawnRate;
    private Fruit lastFruit;
    [SerializeField] private CannonType type = CannonType.upperCannon;
    private List<Fruit> fruitList;
    private int coinDropRate;
    void Start()
    {
        coinDropRate = PlayerPrefs.GetInt("CoinDropRate");
        randomTimerSpawnRate = Random.Range(10, 15);
        randomCoinSpawnRate= Random.Range(coinDropRate, coinDropRate+5);
        fruitList = Canon_Group.Instance.fruitList;
        
        //StartCoroutine(SpawnCounter());
    }

    public void spawnFruit()
    {
        if(Canon_Group.Instance.spawnTimerCounter >= randomTimerSpawnRate)
        {
            lastFruit = Instantiate(fruitList[10], transform.position, Quaternion.identity);
            randomTimerSpawnRate = Random.Range(10, 15);
            Canon_Group.Instance.spawnTimerCounter = 0;

        }
        else if (Canon_Group.Instance.spawnCoinCounter >= randomCoinSpawnRate)
        {
            lastFruit = Instantiate(fruitList[9], transform.position, Quaternion.identity);
            randomCoinSpawnRate = Random.Range(coinDropRate, coinDropRate+5);
            Canon_Group.Instance.spawnCoinCounter = 0;
            
        }
        else
        {
            lastFruit = Instantiate(fruitList[Random.Range(0, fruitList.Count - 2)], transform.position, Quaternion.identity);
        }
        Canon_Group.Instance.spawnTimerCounter++;
        Canon_Group.Instance.spawnCoinCounter++;
        lastFruit.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-.1f, .1f), ForceMode2D.Impulse);
        switch (type)
        {
            case CannonType.upperCannon:
                
                break;

            case CannonType.leftSideCannon:
                lastFruit.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(1f, 2.5f), 0), ForceMode2D.Impulse);
                break;

            case CannonType.rightSideCannon:
                lastFruit.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,-2.5f), 0), ForceMode2D.Impulse);
                break;

            case CannonType.leftUpperCrossCannon:
                lastFruit.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(.5f, 1.5f), -.3f), ForceMode2D.Impulse);
                break;

            case CannonType.rightUpperCrossCannon:
                lastFruit.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-.5f, -1.5f), -.3f), ForceMode2D.Impulse);
                break;

            case CannonType.leftLowerCannon:
                lastFruit.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(.5f, 1.2f), 5f), ForceMode2D.Impulse);
                break;

            case CannonType.rightLowerCannon:
                lastFruit.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-.5f, -1.2f), 5f), ForceMode2D.Impulse);
                break;
        }
        
    }
}
