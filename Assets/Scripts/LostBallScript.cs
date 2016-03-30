using UnityEngine;
using System.Collections;

public class LostBallScript : MonoBehaviour
{
    //evento che viene scatenato dal Box Collider impostato come trigger
    //quando un altro collider entra nella zona di collisione
    void OnTriggerEnter(Collider coll)
    {
        //se il collider è quello dell'oggetto Ball ricomincio
        if (coll.gameObject.name == "Ball")
            GameManagerScript.singleton.LoseBall();
    }
}
