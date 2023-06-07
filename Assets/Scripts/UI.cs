using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] RawImage finishTab;
    [SerializeField] RawImage deathTab;
    [SerializeField] TMP_Text scoreResultField;
    [SerializeField] Score scoreSystem;

    private void Start()
    {
        deathTab.gameObject.SetActive(false);
        finishTab.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        Crash.OnPlayerDied += EnableDeathTab;
        Finish.OnPlayerFinished += EnableFinishTab;
    }


    private void OnDisable()
    {
        Crash.OnPlayerDied -= EnableDeathTab;
        Finish.OnPlayerFinished -= EnableFinishTab;
    }


    private void EnableDeathTab(Vector3 playerPos)
    {
        deathTab.gameObject.SetActive(true);
        scoreResultField.text = "Your score:" + scoreSystem.score;
        Time.timeScale = 0;
    }


    private void EnableFinishTab()
    {
        finishTab.gameObject.SetActive(true);
        Time.timeScale = 0;
    }


    public void Quit()
    {
        Application.Quit();
    }


    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
