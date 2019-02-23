using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGeneration : MonoBehaviour
{

    public ObjectPooling coinPool;
    public float distanceBetweenCoins;
    GameObject[] coins;
    private int coinNumber;

    public void SpawnCoins(Vector3 startPosition)
    {
        coinNumber = Random.Range(0, 3);

        for (int i = 0; i <= coinNumber; i++)
        {
            if (coinNumber == 0)
            {
                GameObject coin1 = coinPool.GetPoolObject();
                coin1.transform.position = startPosition;
                coin1.SetActive(true);
                return;
            }

            if (coinNumber == 1)
            {
                GameObject coin1 = coinPool.GetPoolObject();
                coin1.transform.position = startPosition;
                coin1.SetActive(true);

                GameObject coin2 = coinPool.GetPoolObject();
                coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
                coin2.SetActive(true);
                return;
            }

            if (coinNumber == 2)
            {
                GameObject coin1 = coinPool.GetPoolObject();
                coin1.transform.position = startPosition;
                coin1.SetActive(true);

                GameObject coin2 = coinPool.GetPoolObject();
                coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
                coin2.SetActive(true);

                GameObject coin3 = coinPool.GetPoolObject();
                coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
                coin3.SetActive(true);
                return;
            }
        }
    }
}
