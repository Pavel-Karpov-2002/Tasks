using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth; // ������������� ����������� �� ��������� ��������

    private int health; // �������� ������

    public int Health => health;
    public int MaxHealth => maxHealth;  

    // ����������� ��� ������ �����
    private void Start()
    {
        health = maxHealth; // �������� �� ����������� ��������
    }

    // ������� ���������� �� ������� ������ � �������� �������� �� 10 � -10
    public void ChangeAmountHealth(int amount)
    {
        Debug.Log(health); // ����� ���������� �� ���������� ��������
        if (health + amount > maxHealth || health + amount < 0) // ����������� �� ����������� � ���������� �������� �������� (�� ����� N � �� ����� 0)
            return;
        health += amount; // �������� �������� �� ��������
    }
}
