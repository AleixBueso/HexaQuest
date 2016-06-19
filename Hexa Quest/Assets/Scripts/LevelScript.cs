using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelScript : MonoBehaviour
{

    public float AttackCD;
    float AttackTime;
    public int PlayerDamage;
    public int BossDamage;
    public int BossHP;
    public GameObject Player;
    public GameObject Boss;
    public Slider HealthBar;
    public Text CurrentHealth;
    public GameObject tile_1;



    // Use this for initialization
    void Start()
    {
        FlotatingDamageControllerScript.Initialize();
        HealthBar.value = BossHP;
        AttackTime = AttackCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //iTween.MoveTo(Player, posició seguent tile, 0.5f);
            //iTween.RotateTo(Player, new Vector3(0, -60, 0), 0.5f);
            
            Player.transform.Translate(new Vector3(15, 0, 17.32f / 2));
            Player.transform.Rotate(new Vector3(0, -60, 0));

            AttackTime = AttackCD;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //iTween.RotateTo(Player, new Vector3(0, 60, 0), 0.5f);
            //iTween.MoveTo(Player, posició anterior tile, 0.5f);

            Player.transform.Rotate(new Vector3(0, 60, 0));
            Player.transform.Translate(new Vector3(-15, 0, -17.32f / 2));

            AttackTime = AttackCD;
        }

        else
        {
            AttackTime -= Time.deltaTime;
            if (AttackTime < 0 || Input.GetKeyDown(KeyCode.Space))
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