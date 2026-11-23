using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            GameMultiplayer.Instance.StartHost();
            Debug.Log("Host Started");
            Show(false);
        });

        clientButton.onClick.AddListener(() =>
        {
            GameMultiplayer.Instance.StartClient();
            Debug.Log("Client Started");
            Show(false);

        });
    }

    private void Show(bool show)
    {
        this.gameObject.SetActive(show);
    }


}
