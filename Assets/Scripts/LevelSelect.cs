using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public WeatherManager weatherManager;
    public Dropdown cityDropdown;

    private void Start()
    {
        cityDropdown = GetComponent<Dropdown>();

        string[] cityNames = System.Enum.GetNames(typeof(WeatherManager.City));

        List<string> options = new List<string>(cityNames);

        cityDropdown.ClearOptions();
        cityDropdown.AddOptions(options);
        cityDropdown.onValueChanged.AddListener(OnCityChanged);
    }

    public void OnCityChanged(int index)
    {
        // Convert the dropdown index to the enum
        WeatherManager.City selectedCity = (WeatherManager.City)index;

        // Pass it to your WeatherManager
        weatherManager.UpdateWeather(selectedCity);
    }
}

