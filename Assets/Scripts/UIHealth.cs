using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // ��������
    [SerializeField] private Player player; // ����� ������
    [SerializeField] private float healthSliderSpeed; // �������� ��������� �������� value � ��������

    private void Start()
    {
        healthSlider.maxValue = player.MaxHealth; // ������ ������������ value ��� �������� ������ ������������� �������� ������ 
        healthSlider.value = player.Health; // ������ ��������� �������� �������� �� ���������� �������� ��� ������ �����
    }

    private void FixedUpdate()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, player.Health, Time.deltaTime * healthSliderSpeed); // ������ �������� �������� �������� �������� ��� ��������� �������� ������ 
    }
}
