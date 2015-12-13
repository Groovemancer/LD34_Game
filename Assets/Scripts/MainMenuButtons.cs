using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour
{

    public void PlayButtonClick()
    {
        Debug.Log("Play game!");
        LevelLoader.LoadLevel("Gameplay");
    }

    public void QuitButtonClick()
    {
        Debug.Log("Quit game!");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
