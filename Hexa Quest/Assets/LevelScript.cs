using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelScript : MonoBehaviour {

    public float AttackCD;
    float AttackTime;
    public int PlayerDamage;
    public int BossDamage;
    public int BossHP;
    public GameObject Player;
    public Slider HealthBar;
    public Text CurrentHealth;

	// Use this for initialization
	void Start ()
    {
        HealthBar.value = BossHP;
        AttackTime = AttackCD;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player.transform.Translate(new Vector3(15, 0, 17.32f / 2));
            Player.transform.Rotate(new Vector3(0, -60, 0));
            AttackTime = AttackCD;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Player.transform.Rotate(new Vector3(0, 60, 0));
            Player.transform.Translate(new Vector3(-15, 0, -17.32f / 2));
            AttackTime = AttackCD;
        }

        else
        {
            AttackTime -= Time.deltaTime;
            if (AttackTime < 0)
            {
                HealthBar.value -= PlayerDamage;
                AttackTime = AttackCD;
            }

            
        }

        CurrentHealth.text = HealthBar.value + " / " + BossHP + " HP";
    }
}
