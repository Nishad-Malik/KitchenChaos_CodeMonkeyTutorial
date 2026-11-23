using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI key_MoveUpText;
    [SerializeField] private TextMeshProUGUI key_MoveDownText;
    [SerializeField] private TextMeshProUGUI key_MoveLeftText;
    [SerializeField] private TextMeshProUGUI key_MoveRightText;
    [SerializeField] private TextMeshProUGUI key_InteractText;
    [SerializeField] private TextMeshProUGUI key_InteractAltText;
    [SerializeField] private TextMeshProUGUI key_PauseText;
    [SerializeField] private TextMeshProUGUI key_GamepadInteract;
    [SerializeField] private TextMeshProUGUI key_GamepadInteractAlt;
    [SerializeField] private TextMeshProUGUI key_GamepadPause;


    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;

        GameManager.Instance.OnLocalPlayerReadyChanged += GameManager_OnLocalPlayerReadyChanged;

        UpdateVisual();

        Show();
    }

    private void GameManager_OnLocalPlayerReadyChanged(object sender, EventArgs e)
    {
        if(GameManager.Instance.IsLocalPlayerReady())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {

        key_MoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        key_MoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        key_MoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        key_MoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        key_InteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        key_InteractAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        key_PauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        key_GamepadInteract.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        key_GamepadInteractAlt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        key_GamepadPause.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
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
