using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class KitchenObject : NetworkBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private I_KitchenObjectParent kitchenObjectParent;

    private FollowTransform followTransform;


    protected virtual void Awake()
    {
        followTransform = this.GetComponent<FollowTransform>();
    }

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(I_KitchenObjectParent newKitchenObjectParent)
    {
        SetKitchenObjectParentServerRpc(newKitchenObjectParent.GetNetworkObject());
    }


    [ServerRpc(RequireOwnership = false)]
    private void SetKitchenObjectParentServerRpc(NetworkObjectReference kitchenObjectParentNetworkObjectReference)
    {
        SetKitchenObjectParentClientRpc(kitchenObjectParentNetworkObjectReference);  
    }

    [ClientRpc]
    private void SetKitchenObjectParentClientRpc(NetworkObjectReference kitchenObjectParentNetworkObjectReference)
    {
        kitchenObjectParentNetworkObjectReference.TryGet(out NetworkObject kitchenObjectParentNetworkObject);

        I_KitchenObjectParent newKitchenObjectParent = kitchenObjectParentNetworkObject.GetComponent<I_KitchenObjectParent>();

        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }

        this.kitchenObjectParent = newKitchenObjectParent;

        if (newKitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError($"This KitchenObjectParent already has a Kitchen Object");
        }

        newKitchenObjectParent.SetKitchenObject(this);

        followTransform.SetTargetTransform(newKitchenObjectParent.GetKitchenObjectTransformFollow());

        //transform.parent = newKitchenObjectParent.GetKitchenObjectTransformFollow();

        //transform.localPosition = Vector3.zero;
    }

    public I_KitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public void ClearKitchenObjectOnParent()
    {
        kitchenObjectParent.ClearKitchenObject();
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if(this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;

            return true;
        }

        plateKitchenObject = null;

        return false;
    }

    public static void SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, I_KitchenObjectParent kitchenObjectParent)
    {
        GameMultiplayer.Instance.SpawnKitchenObject(kitchenObjectSO, kitchenObjectParent);
    }

    public static void DestroyKitchenObject(KitchenObject kitchenObject)
    {
        GameMultiplayer.Instance.DestroyKitchenObject(kitchenObject);
    }
}
