using UnityEngine;
using System.Collections;

public class EffectDamage : Effect
{
    public int damage = 0;

    private GameObject gameSettings;
    private HealthSystem healthSystem;

    // Use this for initialization
    void Start()
    {
        gameSettings = GameObject.FindGameObjectWithTag("GameSettings");
        healthSystem = gameSettings.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ApplyEffect(GameObject go)
    {
        healthSystem.ReceiveDamage(damage);
    }
}
