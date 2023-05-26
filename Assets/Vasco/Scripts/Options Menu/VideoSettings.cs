using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] private int xResolution;
    [SerializeField] private int yResolution;
    [SerializeField] private bool isFullscreen = true;


    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutuionIndex;

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle;

    public void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        FillResolutionDropdown();
        SetResolution();
        SetFullscreen(true);
        ApplySettings();
    }

    private void FillResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        foreach (Resolution resolution in resolutions)
            if (resolution.refreshRate == currentRefreshRate)
                filteredResolutions.Add(resolution);


        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
                currentResolutuionIndex = i;

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutuionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution()
    {
        string[] res = resolutionDropdown.options[resolutionDropdown.value].text.Split('x');

        xResolution = int.Parse(res[0]);

        string[] HRes = res[1].Split(' ');

        yResolution = int.Parse(HRes[0]);
    }

    public void SetFullscreen(bool fullscreen)
    {
        isFullscreen = fullscreen;
    }

    public void ApplySettings()
    {
        Screen.SetResolution(xResolution, yResolution, isFullscreen);
    }
}
