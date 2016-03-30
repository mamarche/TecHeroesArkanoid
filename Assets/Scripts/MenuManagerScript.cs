using UnityEngine;
using System.Collections;

public class MenuManagerScript : MonoBehaviour {

	public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
