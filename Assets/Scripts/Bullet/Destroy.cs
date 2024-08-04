using JetBrains.Annotations;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public SpawnEnemy SpawnEnemy;
    public Shoot shoot;
    public Stats stats;
    public TowerStats towerStats;
    public Upgrade upgrade;

    [SerializeField]
    private float dis;

    private void Start()
    {
        SpawnEnemy = GameObject.Find("SpawnPoint0").GetComponent<SpawnEnemy>(); 
        shoot = GameObject.Find("Tower").GetComponent<Shoot>();
        towerStats = GameObject.Find("Tower").GetComponent<TowerStats>();
        upgrade = GameObject.Find("Canvas").GetComponent<Upgrade>();
    }

    private void Update()
    {
        dis = Vector2.Distance(towerStats.transform.position, transform.position);

        if(dis > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {           
            Destroy(this.gameObject);
            stats = collision.GetComponent<Stats>();
            stats.SetHealth(towerStats.GetBulletDamage());
            if(stats.GetHealth() <= 0)
            {
                Destroy(collision.gameObject);
                //towerStats.SetExperience();
                towerStats.SetExperience(stats.GetExperience());
                SpawnEnemy.mobs.Remove(collision.gameObject);
            }
        }     
    }
}
