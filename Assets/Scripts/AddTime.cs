using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour,ITargetable
{
    [SerializeField] private int addedTime;

    public int StartTarget()
    {

        FindFirstObjectByType<PlayerControl>().AddTime(addedTime);
        return 0;
    }
}
