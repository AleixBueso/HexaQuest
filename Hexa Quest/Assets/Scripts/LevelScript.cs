using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelScript : MonoBehaviour
{

    public float AttackCD;
    public float Evasion;
    float AttackTime;
    float DodgeTime;
    public int PlayerDamage;
    public int BossDamage;
    public int BossHP;
    public GameObject Player;
    public GameObject Boss;
    public Slider HealthBar;
    public Text CurrentHealth;

    //Tiles Logic
    public GameObject[] Tiles;
    public int CurrentTile = 0;

    // Use this for initialization
    void Start()
    {
        
        FlotatingDamageControllerScript.Initialize();
        HealthBar.value = BossHP;
        AttackTime = AttackCD;
        DodgeTime = Evasion;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && DodgeTime <= 0)
        {
            if (CurrentTile == 5)
            {
                iTween.MoveTo(Player, Tiles[0].transform.position /*+ new Vector3(0, 2, 0)*/, 0.5f);
                CurrentTile = 0;
            }

            else
                iTween.MoveTo(Player, Tiles[++CurrentTile].transform.position /*+ new Vector3(0, 2, 0)*/, 0.5f);
            iTween.RotateAdd(Player, new Vector3(0, -60, 0), 0.5f);

            AttackTime = AttackCD;
            DodgeTime = Evasion;

            Debug.Log(CurrentTile);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && DodgeTime <= 0)
        {

            iTween.RotateAdd(Player, new Vector3(0, 60, 0), 0.5f);

            if (CurrentTile == 0)
            {
                iTween.MoveTo(Player, Tiles[5].transform.position /*+ new Vector3(0, 2, 0)*/, 0.5f);
                CurrentTile = 5;

            }

            else
                iTween.MoveTo(Player, Tiles[--CurrentTile].transform.position /*+ new Vector3(0, 2, 0)*/, 0.5f);

            AttackTime = AttackCD;
            DodgeTime = Evasion;

            Debug.Log(CurrentTile);
        }

       

        else
        {
            AttackTime -= Time.deltaTime;
            DodgeTime -= Time.deltaTime;
            if (/*AttackTime < 0 ||*/ Input.GetKeyDown(KeyCode.Space))
            {
                if (Boss)
                {
                    FlotatingDamageControllerScript.CreateFloatingText(PlayerDamage.ToString(), Boss.transform);
                    HealthBar.value -= PlayerDamage;
                    AttackTime = AttackCD;
                }
            }
        }

        CurrentHealth.text = HealthBar.value + " / " + BossHP + " HP";

        if(HealthBar.value <= 0)
        {
            Destroy(Boss.gameObject);
        }
    }
}