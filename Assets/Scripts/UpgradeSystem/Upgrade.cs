using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [Header("Component")]
    public TowerStats towerStats;
    public Shoot shoot;
    public GameObject systemUpgrade;
    public GameObject dead;
    public GameObject button;
    public SpawnEnemy spaEnemy;

    [Header("Component Array/Lists")]
    public Image[] image = new Image[3];
    public TextMeshProUGUI[] upgradeText = new TextMeshProUGUI[3];
    public Sprite[] upgradeIcon = new Sprite[4];
    public string[] spriteDescription = new string[4];
    public int[] lvl = new int[40];
      
    [Header("Variable")]
    [SerializeField]
    private float chanceToDrop;
    [SerializeField]
    private float upgradeSeat;
    [SerializeField]
    private bool z = true;
    [SerializeField]
    private int lvll = 0;


    // Start is called before the first frame update
    void Start()
    {
        towerStats = GameObject.Find("Tower").GetComponent<TowerStats>();
        shoot = GameObject.Find("Tower").GetComponent<Shoot>();

        systemUpgrade.SetActive(false);
        dead.SetActive(false);
        button.SetActive(false);
    }

    private void Update()
    {
        if(systemUpgrade.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                WhatChose(image[0].sprite.name);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                WhatChose(image[1].sprite.name);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                WhatChose(image[2].sprite.name);
            }
        }


        if (lvll < lvl.Length)
        {
            if (towerStats.GetExperience() >= lvl[lvll] && z == true)
            {
                //Debug.Log("Upgrade LVL: " + lvl[lvll].ToString());
                Time.timeScale = 0;
                systemUpgrade.SetActive(true);
                if (z == true)
                {
                    UpgradeSystem();
                }
                lvll++;

                //Debug.Log("Upgrade: " + lvll + " Level: " + lvl.Length + " EXP: " + towerStats.GetExperience() + " Sekundy: " + spaEnemy.GetSeconds() + " Moby:  " + spaEnemy.GetWhichEnemy());
            }
        }

    }

    private void UpgradeSystem()
    {
        float chanceToDrop = Mathf.Round(Random.Range(0, 1.0f) * 100) / 100;

        //Debug.Log("chanceToDrop: " + chanceToDrop);

        if (chanceToDrop >= 0.5f)
        {
            upgradeSeat = Random.Range(0, 3);
        }

        for (int i = 0; i < 3; i++)
        {

            if (i == upgradeSeat && chanceToDrop >= 0.5f)
            {
                image[i].sprite = upgradeIcon[3];
                image[i].SetNativeSize();
                upgradeText[i].text = spriteDescription[3];
            }else
            {
                image[i].sprite = upgradeIcon[i];
                image[i].SetNativeSize();
                upgradeText[i].text = spriteDescription[i];
            }
        }

        z = true;
    }

    private void WhatChose(string chose)
    {
        switch(chose)
        {
            case "SwordIcon":
                //Debug.Log("To jest miecz");
                towerStats.SetBulletDamage();
                break;
            case "Plus":
                //Debug.Log("To jest Plus");
                towerStats.SetMaxHP();
                break;
            case "BulletFast":
                //Debug.Log("To jest BulletFast");
                shoot.SetBulletFast();
                break;
            case "BulletUpgrade":
                //Debug.Log("To jest BulletUpgrade");
                shoot.SetAmountBullet();
                break;
        }

        systemUpgrade.SetActive(false);
        z = true;
        Time.timeScale = 1;
    }

    public void onTryAgainButton()
    {
        SceneManager.LoadScene(0);      
    }

    public void Button()
    {
        button.SetActive(true);
    }

    public void zero()
    {
        WhatChose(image[0].sprite.name);
    }

    public void one()
    {
        WhatChose(image[1].sprite.name);
    }

    public void two()
    {
        WhatChose(image[2].sprite.name);
    }



}
