using UnityEngine;
using System.Collections;

public class EffectScore : Effect
{
    public int scoreValue = 0;

    private GameObject gameSettings;
    private ScoreSystem scoreSystem;

    // Use this for initialization
    void Start()
    {
        gameSettings = GameObject.FindGameObjectWithTag("GameSettings");
        scoreSystem = gameSettings.GetComponent<ScoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ApplyEffect(GameObject go)
    {
        scoreSystem.GainScore(scoreValue);
    }
}
