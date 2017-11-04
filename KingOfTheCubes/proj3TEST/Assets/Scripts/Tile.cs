using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    protected MeshRenderer mr;
    protected BoxCollider c;
    public float respawnTimeStamp, respawnTime, floorSize, suddenDeathTimeStamp;
    public bool isBreakable, active;
    public int hp;
    //public GameObject holePrefab;
    

    // Use this for initialization
    protected void Start () {
        mr = transform.GetComponent<MeshRenderer>();
        c = transform.GetComponent<BoxCollider>();
        //hole = transform.GetComponent<CircleCollider2D>();
        respawnTime = 40.0f;
        //respawnTimeStamp = 0;
        floorSize = .32f;
        Reset();
    }

    public void Reset()
    {
        active = true;
        respawnTimeStamp = 0;
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetRespawnTime()
    {
        //print("res");
        respawnTimeStamp = GameManager.time + respawnTime;
    }

    public void Break()
    {
        SetRespawnTime();
    }
	
	// Update is called once per frame
	protected void Update ()
    {
		active = respawnTimeStamp <= GameManager.time; // && suddenDeathTimeStamp >= GameManager.time;
        mr.enabled = active;
        c.enabled = active;
    }
}
