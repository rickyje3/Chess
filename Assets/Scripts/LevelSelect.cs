using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public WeatherManager weatherManager;
    public Dropdown cityDropdown;

    private void Start()
    {
        cityDropdown = GetComponent<Dropdown>();

        cityDropdown.ClearOptions();
        cityDropdown.AddOptions(weatherManager.cities);
        cityDropdown.onValueChanged.AddListener(OnCityChanged);
    }

    public void OnCityChanged(int index)
    {
        weatherManager.UpdateWeather(weatherManager.cities[index]);
    }
}

