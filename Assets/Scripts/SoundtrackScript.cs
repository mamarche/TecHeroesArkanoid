using UnityEngine;
using System.Collections;

public class SoundtrackScript : MonoBehaviour
{
    public static SoundtrackScript singleton = null;

    void Awake()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            singleton = this;
        }
        DontDestroyOnLoad(gameObject);
    }

}
