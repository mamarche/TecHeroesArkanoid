using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //riferimento all'oggetto Paddle
    public GameObject paddle;
    //riferimento alla posizione di partenza del paddle
    public Transform paddleStartPosition;
    //riferimento all'oggetto ScoreText
    public Text scoreText;
    //riferimento all'oggetto BallText
    public Text ballText;
    //riferimento al pannello dei pulsanti
    public GameObject menuPanel;

    //variabili per la gestione dei punti e delle palle
    private int currentScore = 0;
    private int balls = 3;

    //membro statico per l'implementazione del pattern singleton
    public static GameManagerScript singleton;

    //metodo richiamato automaticamente da Unity alla creazione dell'oggetto
    void Awake()
    {
        //imposto il membro statico con l'istanza corrente
        singleton = this;
    }

    //metodo richiamato automaticamente da Unity prima del primo ciclo di Update
    void Start()
    {
        menuPanel.SetActive(false);
        //richiama la funzione di inizializzazione del livello
        InitGame();
    }

    //metodo che inizializza gli oggetti
    public void InitGame()
    {
        ResetPaddle();
        //imposto il numero dell palle a 4 per comodità (vedi riga sotto)
        balls = 4;
        //Richiamo il metodo LoseBall per aggiornare il testo a video
        LoseBall();

        //azzero il punteggio
        currentScore = 0;
        //aggiorno il testo a video richiamando il metodo e passando 0
        AddScore(0);
    }

    //metodo che riporta il paddle allo stato iniziale e "ancora" la palla
    public void ResetPaddle()
    {
        paddle.transform.position = paddleStartPosition.position;
        paddle.GetComponent<PaddleScript>().LockBall();
    }

    //Metodo per incrementare il punteggio
    public void AddScore(int score)
    {
        //incremento la variabile del punteggio
        currentScore += score;
        //aggiorno il testo a video
        scoreText.text = string.Format("Score: {0}", currentScore);
    }
    //Metodo per decrementare le palle a disposizione
    public void LoseBall()
    {
        //decremento la variabile delle palle
        balls--;
        //aggiorno il testo a video
        ballText.text = string.Format("Balls: {0}", balls);

        if (balls < 0)
            GameOver();
        else
            //reimposto il paddle nella posizione iniziale
            ResetPaddle();
    }

    void GameOver()
    {
        menuPanel.SetActive(true);
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
