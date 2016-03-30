using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        //verifica se l'oggetto entrato in collisione è la palla
        if (collision.gameObject.name == "Ball")
        {
            //Aggiorno il punteggio
            GameManagerScript.singleton.AddScore(10);
            //se si tratta della palla, distrugge il GameObject (ovvero il Brick che è stato colpito)
            Destroy(gameObject);
        }
    }
}
