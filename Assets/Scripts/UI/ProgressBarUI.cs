using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;

    private I_HasProgress hasProgress;

    [SerializeField] private Image barImage;

    
    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<I_HasProgress>();

        if(hasProgress == null)
        {
            Debug.LogError($"The game object {hasProgressGameObject} does not have a component that implements I_HasProgress!");
        }

        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        barImage.fillAmount = 0f;

        this.Hide();
    }


  

    private void HasProgress_OnProgressChanged(object sender, I_HasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            this.Hide();
        }
        else
        {
            this.Show();
        }

    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
