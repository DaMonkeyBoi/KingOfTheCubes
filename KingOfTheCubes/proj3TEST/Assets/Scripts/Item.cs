using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public float timeToLive, activeTimeStamp;
    public int uses, team;
    public bool activate;
	// Use this for initialization
	void Start () {
        activate = false;
        uses = 2;
        timeToLive = 10;
        activeTimeStamp = 0;// GameManager.time + timeToLive;
	}
	
	// Update is called once per frame
	void Update () {
        //if (activeTimeStamp <= GameManager.time)
        //    Destroy(gameObject);
	}

    public int Use(PlayerController p)
    {
        //print("USING");
        uses--;
        if(uses == 0)
           Destroy(gameObject);
        return uses;
    }
    
}
