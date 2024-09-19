using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private static Image healthBar;
    private static float maxHP;

    public void Awake()
    {
        healthBar = GetComponent<Image>();
    }

    public static void UpdateImage(float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHP;
    }

    public static void RegisterStats(float stats)
    {
        maxHP = stats;
    }
}
