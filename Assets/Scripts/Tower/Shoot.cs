using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Another Scripts")]
    public SpawnEnemy SpawnEnemy;
    public Menu menu;
    public TowerStats towerStats;

    [Header("Component")]
    public GameObject prefabBullet;
    public GameObject bullet;
    public Transform point;
    public Transform gunPoint;
    public Transform bullets;

    [Header("Variable")]
    private bool shoot = true;
    private Vector3 direction;
    private Vector3 target;
    private int z = 0;
    private int amountBullet = 1;
    private float shootBulletFast = 3f;
    private float bulletFast = 0.2f;

    private void Start()
    {
        SpawnEnemy = GameObject.Find("SpawnPoint0").GetComponent<SpawnEnemy>();
        point = GameObject.Find("Point").GetComponent<Transform>();
        gunPoint = GameObject.Find("GunPoint").GetComponent<Transform>();
        menu = GameObject.Find("Canvas").GetComponent<Menu>();
    }

    private void Update()
    {
        if (shoot == true && SpawnEnemy.mobs.Count > 0)
        {
            StartCoroutine(ShootBullet());
        }
    }

    public IEnumerator ShootBullet()
    {
        shoot = false;

        for (int i = 0; i < amountBullet; i++)
        {
            if(SpawnEnemy.mobs.Count - 1 < i)
            {             
                break;
            }

            point.transform.rotation = Quaternion.Euler(0, 0, CalculateAngle(transform.position, SpawnEnemy.mobs[i].transform.position));

            bullet = Instantiate(prefabBullet, gunPoint.transform.position, Quaternion.Euler(0, 0, CalculateAngle(transform.position, SpawnEnemy.mobs[i].transform.position)));

            target = SpawnEnemy.mobs[i].transform.position;

            bullet.name = "Bullet " + z;

            bullet.transform.SetParent(bullets);

            direction = Direction(SpawnEnemy.mobs[i].transform.position, bullet.transform.position);

            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.AddForce(bullet.transform.position + (direction * bulletFast), ForceMode2D.Impulse);

            z++;
        }

        yield return new WaitForSeconds(shootBulletFast);

        shoot = true;
    }

    float CalculateAngle(Vector2 objectOne, Vector2 ObjectTwo)
    {
        Vector3 direction = objectOne - ObjectTwo;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle + 90;

    }

    Vector3 Direction(Vector3 objectOne, Vector3 ObjectTwo)
    {
        Vector3 direction = objectOne - ObjectTwo;
        direction.Normalize();

        return direction;
    }

    public void SetAmountBullet()
    {
        amountBullet = amountBullet + 1;
    }

    public void SetBulletFast()
    {
        if(shootBulletFast < 0.5f)
        {
            bulletFast = bulletFast + 0.1f;
            shootBulletFast = shootBulletFast - 0.15f;
        }
        else
        {
            bulletFast = bulletFast + 0.1f;
            towerStats.SettBulletDamage(2);
        }

    }
}

