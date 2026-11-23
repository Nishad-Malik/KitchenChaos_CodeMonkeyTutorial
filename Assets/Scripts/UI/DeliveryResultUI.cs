using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POP_UP = "PopUp";

    [SerializeField] private Image backgroundImage;

    [SerializeField] private Image iconImage;

    [SerializeField] private TextMeshProUGUI messageText;

    [SerializeField] private Color successColor;

    [SerializeField] private Color failColor;

    [SerializeField] private Sprite successSprite;

    [SerializeField] private Sprite failSprite;

    private Animator animator;

    private void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManger_OnRecipeSuccess;

        DeliveryManager.Instance.OnRecipeFail += DeliveryManager_OnRecipeFail;

        gameObject.SetActive(false);

    }

    private void DeliveryManger_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);

        animator.SetTrigger(POP_UP);

        backgroundImage.color = successColor;

        iconImage.sprite = successSprite;

        messageText.text = "DELIVERY\nSUCCESS";
    }

    private void DeliveryManager_OnRecipeFail(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);

        animator.SetTrigger(POP_UP);

        backgroundImage.color = failColor;

        iconImage.sprite = failSprite;

        messageText.text = "DELIVERY\nFAILED";

    }

}
