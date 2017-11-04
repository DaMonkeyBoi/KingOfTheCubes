using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour {
    public float timeToLive, activeTimeStamp;
    public Item item;
    bool taken;
    // Use this for initialization



    void Start()
    {
        timeToLive = 200;
        //item = null;
        //item = GameManager.gameManager.itemPrefabs[0];
        activeTimeStamp = GameManager.time + timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimeStamp <= GameManager.time)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //print("COO");
            PlayerController p = other.transform.GetComponent<PlayerController>();
            Interaction(p);
        }
    }

    public void Interaction(PlayerController p)
    {
        if (!taken)
        {
            taken = true;
            if (p.items[0] == null)
                p.items[0] = Instantiate(item);
            Destroy(gameObject);
        }
    }
}
