using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth; // устанавливаем ограничение по заданному здоровью

    private int _health; // здоровье игрока

    public event Action<int> OnHealthChange; // ивент для вызова в случае изменения здоровья игрока

    public int Health {
        get => _health; // получения значения здоровья
        private set // изменения здоровья только в данном классе
        {
            _health = value;
            OnHealthChange?.Invoke(_health); // вызов метода обновления health bar'a 
        }
    }

    public int MaxHealth => _maxHealth; // получения значения максимального здоровья

    // Запускается при старте скрипта
    private void Awake()
    {
        _health = _maxHealth; // здоровье на максимально заданное
    }

    // Отнять здоровье
    public void TakeDamage(int amount)
    {
        if (_health - amount < 0) // ограничение на минимальное здоровье
            return;
        Health -= amount; // отнимание здоровья
    }

    // Добавить здоровье
    public void AddHealth(int amount)
    {
        if (_health + amount > _maxHealth) // ограничение на максимально заданное здоровье
            return;
        Health += amount; // добавление здоровья
    }
}
