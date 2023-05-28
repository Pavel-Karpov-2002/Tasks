using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth; // устанавливаем ограничение по заданному здоровью

    private int health; // здоровье игрока

    public int Health => health;
    public int MaxHealth => maxHealth;  

    // Запускается при старте сцены
    private void Start()
    {
        health = maxHealth; // здоровье на максимально заданное
    }

    // функция вызывается по нажатию кнопки и изменяет здоровье на 10 и -10
    public void ChangeAmountHealth(int amount)
    {
        Debug.Log(health); // вывод информации об оставшемся здоровье
        if (health + amount > maxHealth || health + amount < 0) // ограничение на максимально и минимально заданное здоровье (не более N и не менее 0)
            return;
        health += amount; // изменяет здоровье на заданное
    }
}
