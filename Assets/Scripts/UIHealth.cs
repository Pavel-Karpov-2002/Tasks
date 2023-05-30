using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider; // ползунок
    [SerializeField] private Player _player; // объкт игрока
    [SerializeField] private float _healthSliderSpeed; // скорость изменения значения value у ползунка

    private Coroutine _healthBarCoroutine; // корутина для изменения health bar'a

    private void Start()
    {
        _healthSlider.maxValue = _player.MaxHealth; // задает максимальное value для ползунка равное максимальному здоровью игрока 
        _healthSlider.value = _player.Health; // задает начальное значение ползунка на количество здоровья при старте сцены
        _player.OnHealthChange += OnHealthBarChange; // добавлем к ивенту Action функцию
    }

    private void OnHealthBarChange(int health)
    {
        if (_healthBarCoroutine != null) // в случае, если корутина равняется null не вызывается остановка
            StopCoroutine(_healthBarCoroutine); // остановка старой корутины
        _healthBarCoroutine = StartCoroutine(ChangeHealthBar(health)); // запуск корутины
    }

    private IEnumerator ChangeHealthBar(int endValue)
    {
        while(_healthSlider.value != endValue) // пока слайдер здоровья не равен конечному значению (здоровью игрок) цикл не завершается
        {
            yield return null; // продолжает корутину
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, endValue, Time.deltaTime * _healthSliderSpeed); // плавно изменяет значение слайдера здоровья
        }
    }

    private void OnDestroy()
    {
        _player.OnHealthChange -= OnHealthBarChange;
    }
}
