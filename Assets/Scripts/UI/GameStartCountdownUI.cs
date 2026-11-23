using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartCountdownUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "numberPopUp";

    [SerializeField] private TextMeshProUGUI countdownText;

    private Animator animator;

    private int previousCoundownNumber;

    private void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Start()
    { 
        
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();

    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        } else
        {
            Hide();
        }

    }

    private void Update()
    {
        int coundownNumber = Mathf.CeilToInt(GameManager.Instance.GetcountdownToStartTimer());

        countdownText.text = coundownNumber.ToString();

        if(previousCoundownNumber != coundownNumber)
        {
            previousCoundownNumber = coundownNumber;

            animator.SetTrigger(NUMBER_POPUP);
        }

        SoundManager.Instance.PlayCountDownSound();
    }

    private void Show()
    {
        this.gameObject.SetActive(true);
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
