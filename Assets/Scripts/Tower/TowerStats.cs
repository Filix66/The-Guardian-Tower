using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerStats : MonoBehaviour
{
    public Stats stats;
    public SpawnEnemy spawnEnemy;
    public HealthBar healthBar;
    public Upgrade upgrade;
    public Shoot shoot;

    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int experience = 0;
    [SerializeField]
    private int bulletDamage = 5;



    private void Start()
    {
        upgrade = GameObject.Find("Canvas").GetComponent<Upgrade>();
        shoot = GameObject.Find("Tower").GetComponent<Shoot>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);  
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            stats = collision.GetComponent<Stats>();
            TakeDamage(stats.GetDamage()); 
            Destroy(collision.gameObject);
            spawnEnemy.mobs.Remove(collision.gameObject);
            if(currentHealth <= 0)
            {
                upgrade.dead.SetActive(true);
                StartCoroutine(Restart());              
                shoot.StopAllCoroutines();
            }
        }
    }

    public int GetExperience()
    {
        return experience;
    }

    public void SetExperience(int ex)
    {
        experience = experience + ex;
    }

    public void SetMaxHP()
    {
        maxHealth = maxHealth + 20;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public int GetBulletDamage()
    {
        return bulletDamage;
    }
    public void SetBulletDamage()
    {
        bulletDamage = bulletDamage + 5;
    }

    public void SettBulletDamage(int x)
    {
        bulletDamage = bulletDamage + x;
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
