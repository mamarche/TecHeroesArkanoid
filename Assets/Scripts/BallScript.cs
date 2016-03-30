using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    //proprietà gestibile dall'Inspector per modificare la velocità 
    //della palla
    public float speed = 8f;

    //riferimenti ai componenti Audio Source della palla
    public AudioSource laserSound;
    public AudioSource bounceSound;

    public void OnCollisionEnter(Collision collision)
    {
        //se collide con un Brick riproduco il un suono
        if (collision.gameObject.name.Contains("Brick"))
            laserSound.Play();
        else
            //altrimenti riproduco l'altro
            bounceSound.Play();
    }

    //metodo per lanciare la palla
    public void Launch()
    {
        //imposta la velocità del corpo rigido nella direzione della palla 
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
