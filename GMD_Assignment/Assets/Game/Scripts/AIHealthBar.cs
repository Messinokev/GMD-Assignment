using UnityEngine;
using UnityEngine.UI;

public class AIHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color lowHealth;
    public Color highHealth;
    public Vector3 offset;

    void Update()
    {
        if (Camera.main != null)
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    
    
    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health<maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color =
            Color.Lerp(lowHealth, highHealth, slider.normalizedValue);
    }
}
