using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrefabDestroyer : MonoBehaviour
{
    public void DestroyDoorPrefab()
    {
        Destroy(transform.parent.gameObject);
    }
}
