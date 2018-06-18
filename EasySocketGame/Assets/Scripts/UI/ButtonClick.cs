using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart()
    {
        Battlemanager.ins.PlacePlayer();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        Battlemanager.ins.IsPause = true;
        target.SetActive(true);
    }

    public void ResumeGame()
    {
        Battlemanager.ins.IsPause = false;
        target.SetActive(false);
    }

    public void DieGame()
    {
        target.SetActive(false);
        Battlemanager.ins.starList[Battlemanager.ins.playerId].GetComponent<TankPlay>().Die();
        Battlemanager.ins.IsPause = false;
    }
}
