using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{
    //riferimento all'oggetto Ball
    public GameObject ball;
    //parametro per gestire la velocità di movimento del paddle dall'Inspector
    public float speed = 0.2f;

    //booleano che indica se la palla è "ancorata" al paddle
    private bool ballLocked = true;

    //il metodo Update viene richiamato automaticamente N volte al secondo
    void Update()
    {
        //sposta il paddle nella direzione ricavata dall'oggetto Input sull'asse orizzontale
        transform.position = new Vector3(transform.position.x + (Input.GetAxis("Horizontal") * speed),
                                        transform.position.y,
                                        transform.position.z);
        //blocca il movimento se la coordinata x supera il valore 3.8 verso destra)
        if (transform.position.x > 3.8)
            transform.position = new Vector3(3.8f, transform.position.y, transform.position.z);
        //blocca il movimento se la coordinata x supera il valore -4 verso sinistra)
        if (transform.position.x < -3.8)
            transform.position = new Vector3(-3.8f, transform.position.y, transform.position.z);

        //se la palla è "ancorata" imposta la sua posizione in relazione a quella del paddle
        if (ballLocked)
            ball.transform.position = transform.position + Vector3.forward;

        //se viene premuta la barra spaziatrice, la palla viene lanciata
        if (Input.GetKeyUp(KeyCode.Space) && ballLocked)
            UnlockBall();
    }

    //metodo che "ancora" la palla al paddle
    public void LockBall()
    {
        ballLocked = true;
        ball.transform.position = transform.position + Vector3.forward;
    }

    //metodo che lancia la palla "sbloccandola" dal paddle
    public void UnlockBall()
    {
        ballLocked = false;
        //richiama il metodo Launch dello script BallScript
        ball.GetComponent<BallScript>().Launch();
    }

}
