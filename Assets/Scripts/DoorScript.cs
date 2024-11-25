using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerControl>())
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    public void RemoveDoor()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    //private void OnTriggerEnter(Collider doorZone)
    //{
    //    if(doorZone.gameObject.TryGetComponent<PlayerControl>(out PlayerControl player))
    //    {
    //       // Destroy(gameObject);

    //    }
    //}
}
