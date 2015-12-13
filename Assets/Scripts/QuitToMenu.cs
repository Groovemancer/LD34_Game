using UnityEngine;
using System.Collections;

public class QuitToMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            LevelLoader.LoadLevel("MainMenu");
        }
    }
}
