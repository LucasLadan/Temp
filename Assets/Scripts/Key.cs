using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ITargetable
{

    public int StartTarget()
    {

        FindFirstObjectByType<DoorScript>().RemoveDoor();
        Destroy(gameObject);
        return 0;
    }
}
