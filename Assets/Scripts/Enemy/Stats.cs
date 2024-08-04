using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int experience;

    private void Awake()
    {
        //Debug.Log(gameObject.name);

        if (gameObject.name == "Enemy0(Clone)")
        {
            //Debug.Log("purple");
            health = 15;
            speed = 0.2f;
            damage = 5;
            experience = 5;
        }
        else if (gameObject.name == "Enemy1(Clone)")
        {
            //Debug.Log("Pink");
            health = 35;
            speed = 0.25f;
            damage = 10;
            experience = 12;
        }
        else if (gameObject.name == "Enemy2(Clone)")
        {
            //Debug.Log("Gray");
            health = 75;
            speed = 0.35f;
            damage = 10;
            experience = 25;
        }
        else
        {
            //Debug.Log("Red");
            health = 125;
            speed = 0.45f;
            damage = 20;
            experience = 50;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetHealth(int damage)
    {
        health -= damage;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetExperience()
    {
        return experience;
    }

}

