using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 10;

    [SerializeField]
    private int currentHealth;

    private ScoreSystem scoreSystem;

    void Start()
    {
        currentHealth = maxHealth;
        scoreSystem = GetComponent<ScoreSystem>();
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void ReceiveDamage(int amount)
    {
        currentHealth -= amount;

        AtMaxHealth();

        IsDead();
    }

    public void RecoverHealth(int amount)
    {
        currentHealth += amount;

        AtMaxHealth();

        IsDead();
    }

    private void IsDead()
    {
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void AtMaxHealth()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    void GameOver()
    {
        scoreSystem.SaveScore();

        LevelLoader.LoadLevel("GameOver");
    }
}
