using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrefabDestroyer : MonoBehaviour
{
    //В конце анимации открытия двери вызываем этот метод
    public void DestroyDoorPrefab()
    {
        Destroy(transform.parent.gameObject);
    }
}
