using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
    public Item[] itemPrefabs;
    public static float time;
    public GameObject[] players;

    Map map;

    int playerCount;
    public int playersInGame;

	// Use this for initialization
	void Start () {
        if (gameManager == null)
            gameManager = this;
        time = 0;

        playerCount = 4;
        playersInGame = 4;
        players = new GameObject[playerCount];
        for (int i = 0; i < playerCount; i++)
            players[i] = GameObject.FindGameObjectWithTag("Player" + (i + 1));
	    }
	
	// Update is called once per frame
	void Update () {
        time += .1f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("main");
        }
        if (Input.GetKeyDown(KeyCode.E))
            ResetGame();
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            playerCount = (playerCount + 1) % 5;
            if (playerCount < 2)
                playerCount = 2;
            playersInGame = playerCount;
            ResetGame();
        }

        if (playersInGame < 2)
        {
            if (playersInGame == 0)
                print("TIE");
            else
                print("one winner");
            ResetGame();
        }
                // SceneManager.LoadScene("main");
    }

    void ResetGame()
    {
        time = 0;
        GameObject.Find("Map").transform.GetComponent<Map>().Reset();
        playersInGame = playerCount;
        for (int i = 0; i < 4; i++)
        {
            players[i].SetActive(i < playerCount);
            players[i].transform.GetComponent<PlayerController>().Reset();
        }
                //GameObject.Find("Player" + (i + 1)).SetActive(true);
    }
}
