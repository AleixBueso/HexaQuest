using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public uint Damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(15, 0, 17.32f / 2));
            transform.Rotate(new Vector3(0, -60, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 60, 0));
            transform.Translate(new Vector3(- 15, 0, - 17.32f / 2));
        }

        else
        {
            
        }

    }
}
