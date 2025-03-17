using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material sunset;
    public Material day;
    public Material sunrise;
    public Material night;
    public Material rainy;
    public Material snowy;
    public Material cloudy;
    public Light sun;

    /*public void UpdateSkybox(WeatherData data)
    {
        string weatherDescription = data.weather[0].description.ToLower();

        if (weatherDescription.Contains("clear"))
        {
            RenderSettings.skybox = day;
            sun.intensity = 1.0f;
            sun.color = Color.white;
        }
        else if (weatherDescription.Contains("snow"))
        {
            RenderSettings.skybox = snowy;
            sun.intensity = 0.5f;
            sun.color = Color.clear;
        }
        else if (weatherDescription.Contains("rain"))
        {
            RenderSettings.skybox = rainy;
            sun.intensity = 0.2f;
            sun.color = Color.blue;
        }
        else if (weatherDescription.Contains("night"))
        {
            RenderSettings.skybox = night;
            sun.intensity = 0.2f;
            sun.color = Color.black;
        }
        else if (weatherDescription.Contains("cloudy"))
        {
            RenderSettings.skybox = cloudy;
            sun.intensity = 0.5f;
            sun.color = Color.clear;

            DynamicGI.UpdateEnvironment(); // Updates the lighting
        }
    }*/
}

