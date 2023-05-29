using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // ползунок
    [SerializeField] private Player player; // объкт игрока
    [SerializeField] private float healthSliderSpeed; // скорость изменения значения value у ползунка

    private IEnumerator _healthBarCoroutine; // корутина для изменения health bar'a

    private void Start()
    {
        healthSlider.maxValue = player.MaxHealth; // задает максимальное value для ползунка равное максимальному здоровью игрока 
        healthSlider.value = player.Health; // задает начальное значение ползунка на количество здоровья при старте сцены
        player.OnHealthChange += UpdateHealthBar; // добавлем к ивенту Action функцию
    }

    private void UpdateHealthBar(int health)
    {
        if (_healthBarCoroutine != null) // в случае, если корутина равняется null не вызывается остановка
            StopCoroutine(_healthBarCoroutine); // остановка старой корутины
        _healthBarCoroutine = ChangeHealthBar(health); // установка новоого значения для корутины
        StartCoroutine(_healthBarCoroutine); // запуск корутины
    }

    private IEnumerator ChangeHealthBar(int endValue)
    {
        while(healthSlider.value != endValue) // пока слайдер здоровья не равен конечному значению (здоровью игрок) цикл не завершается
        {
            yield return new WaitForFixedUpdate(); // продолжает корутину как при обновлении FixedUpdate
            healthSlider.value = Mathf.MoveTowards(healthSlider.value, endValue, Time.deltaTime * healthSliderSpeed); // плавно изменяет значение слайдера здоровья
        }
    }
}
