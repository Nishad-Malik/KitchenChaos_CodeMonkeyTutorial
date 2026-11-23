using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public interface I_KitchenObjectParent
{
    public Transform GetKitchenObjectTransformFollow();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();

    public NetworkObject GetNetworkObject();
}
