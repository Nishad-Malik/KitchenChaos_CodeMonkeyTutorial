using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoveBurnWarningUI : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;

    

    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

        Hide();
    }

    private void StoveCounter_OnProgressChanged(object sender, I_HasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = 0.3f;

        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        if(show)
        {
            Show();
        } else
        {
            Hide();
        }
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
