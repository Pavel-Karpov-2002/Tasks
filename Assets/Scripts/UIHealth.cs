using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // ползунок
    [SerializeField] private Player player; // объкт игрока
    [SerializeField] private float healthSliderSpeed; // скорость изменения значения value у ползунка

    private void Start()
    {
        healthSlider.maxValue = player.MaxHealth; // задает максимальное value для ползунка равное максимальному здоровью игрока 
        healthSlider.value = player.Health; // задает начальное значение ползунка на количество здоровья при старте сцены
    }

    private void FixedUpdate()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, player.Health, Time.deltaTime * healthSliderSpeed); // плавно изменяет значение слайдера здоровья при изменении здоровья игрока 
    }
}
