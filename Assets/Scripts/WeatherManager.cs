using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherManager: MonoBehaviour
{
    //api key: fc91862964f1444caf7aaa2959fcc5c8

    private const string xmlApi = "https://api.openweathermap.org/data/2.5/weather?q=Orlando,us&mode=xml&appid=APIKEY";

    [SerializeField]
    private string apiKey = "fc91862964f1444caf7aaa2959fcc5c8"; 

    public List<string> cities = new List<string> { "London", "New York", "Tokyo", "Sydney", "Cairo" };

    [SerializeField]
    private SkyboxController skyboxController; 

    private const string apiUrl = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid={1}";

    public IEnumerator GetWeatherJSON(string city, Action<WeatherData> callback)
    {
        string url = string.Format(apiUrl, city, apiKey);
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error fetching weather data: {request.error}");
            }
            else
            {
                string json = request.downloadHandler.text;
                WeatherData data = JsonUtility.FromJson<WeatherData>(json);
                callback?.Invoke(data);
            }
        }
    }

    public void UpdateWeather(string city)
    {
        StartCoroutine(GetWeatherJSON(city, data =>
        {
            Debug.Log($"Weather in {city}: {data.weather[0].description}, Temp: {data.main.temp}°C");
            skyboxController.UpdateSkybox(data);
        }));
    }
}

[Serializable]
public class WeatherData
{
    public List<WeatherCondition> weather;
    public MainWeatherData main;
}

[Serializable]
public class WeatherCondition
{
    public string description;
}

[Serializable]
public class MainWeatherData
{
    public float temp;
}

