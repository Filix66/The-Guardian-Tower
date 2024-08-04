using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Component")]
    public Transform tower;
    public Transform Enemys;
    public Upgrade upgrade;

    [Header("Lists")]
    public List<Transform> spawnPoint = new List<Transform>();
    public List<GameObject> mobs = new List<GameObject>();
    public List<GameObject> prefabsEnemy = new List<GameObject>();

    [Header("Variable")]
    private float rangeX;
    private float rangeY;
    private int whichSpawnPoint;
    private int whichEnemy = 0;
    [SerializeField]
    private int amountMobs = 2;
    [SerializeField]
    private bool stop = true;
    [SerializeField]
    private float time;
    [SerializeField]
    private int seconds;



    private void Start()
    {
        StartCoroutine(SpawnMobs(5.5f));
    }

    private void Update()
    {

        time += Time.deltaTime;

        seconds = (int)time;
        
        if(seconds % 30 == 0 && seconds > 2 && stop == true)
        {
            stop = false;
            if(seconds % 60 == 0)
            {
                amountMobs = amountMobs + 4;
            }
            else
            {
                amountMobs = amountMobs + 2;
            }

            StartCoroutine(Wait());
            //Debug.Log("Wrok" + seconds);
        }

        if (seconds >= 0 && seconds < 120)
        {
            //Debug.Log("0");
            whichEnemy = 0;
        }
        else if (seconds > 120 && seconds < 240)
        {
            //Debug.Log("1");
            whichEnemy = 1;
        }
        else if (seconds > 240 && seconds < 360)
        {
            //Debug.Log("2");
            whichEnemy = 2;
        }
        else
        {
            //Debug.Log("3");
            whichEnemy = 3;
        }

    }

    private IEnumerator SpawnMobs(float waitTime)
    {
        while (true) 
        {
 
            for (int i = 0; i < amountMobs; i++)
            {
                whichSpawnPoint = Random.Range(0, 4);
                //whichEnemy = Random.Range(0, 4);

                if (whichSpawnPoint <= 1)
                {
                    rangeX = Random.Range(-2.5f, 2.5f);
                    rangeY = 0;
                }
                else
                {
                    rangeX = 0;
                    rangeY = Random.Range(-2.0f, 2.0f);
                }

                GameObject Enemy = Instantiate(prefabsEnemy[whichEnemy], spawnPoint[whichSpawnPoint].transform.position + new Vector3(rangeX, rangeY, 0), Quaternion.identity);
                mobs.Add(Enemy);
                Enemy.transform.SetParent(Enemys);
            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        //Debug.Log("Wait Zadzialalo");
        stop = true;
    }

    public int GetSeconds()
    {
        return seconds;
    }

    public int GetWhichEnemy()
    {
        return whichEnemy;
    }


}
