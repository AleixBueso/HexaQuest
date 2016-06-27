using UnityEngine;
using System.Collections;

public class IABossScript : MonoBehaviour {

    //Times
    public float TimeToAttack = 2f;
    public float TimeDelayAttack = 2f;

    //Timers
    public float TimeAttacking;
    public float TimeWaiting;

    //Tiles
    public GameObject[] Tiles;
    int RandomAttack = 0;

    public GameObject[] Hearts;
    uint HeartsNum = 2;

    private ArrayList Attacks;
    bool[] attack;

    public GameObject Player;
    public uint TileToAttack;
    public GameObject Boss;

    private Transform TargetAttack;

    // Use this for initialization
    void Start() {
        FlotatingDamageControllerScript.Initialize();
        Attacks = new ArrayList();
        attack = new bool[6];
        attack[0] = true; attack[1] = false; attack[2] = false; attack[3] = false; attack[4] = false; attack[5] = false;
        Attacks.Add(attack);
        attack[0] = true; attack[1] = true; attack[2] = false; attack[3] = false; attack[4] = false; attack[5] = true;
        Attacks.Add(attack);
        TimeAttacking = TimeDelayAttack;
        TimeWaiting = TimeToAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss)
        {
            if (TimeWaiting <= 0)
            {
                //Attacking Tile
                uint i = 0;
                uint k = 0;
                while (i < Tiles.Length)
                {
                    if (TargetAttack.transform == Tiles[i].transform)
                        k = i;
                    i++;
                }

                TileToAttack = k;

                Tiles[k].GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.white, TimeAttacking);
                if (TimeAttacking <= 0)
                {
                    if (Player.transform.position == Tiles[k].transform.position)
                    {
                        Debug.Log("Boss hit you!");
                        iTween.ShakePosition(Player, new Vector3(1, 1, 1), 0.2f);
                        Destroy(Hearts[HeartsNum--]);
                    }

                    TimeWaiting = TimeToAttack;
                    TimeAttacking = TimeDelayAttack;
                    Tiles[k].GetComponent<Renderer>().material.color = Color.white;
                }

                else
                    TimeAttacking -= Time.deltaTime;
            }

            else
            {
                if (Player)
                {
                    RandomAttack = Random.Range(0, Tiles.Length - 1);
                    TargetAttack = Tiles[RandomAttack].transform;
                }

                TimeWaiting -= Time.deltaTime;
            }
        }
    }
}
