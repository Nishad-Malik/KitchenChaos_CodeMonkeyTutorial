using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerAnimator : NetworkBehaviour
{
    private Animator animator;

    [SerializeField] private Player player;

    private const string IS_WALKING = "IsWalking";

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!IsOwner) return;

        animator.SetBool(IS_WALKING, player.IsWalking());
    }


}
