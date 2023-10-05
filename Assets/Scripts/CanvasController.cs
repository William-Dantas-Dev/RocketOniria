using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [Header("References")]
    public RocketCameraController rocketCameraController;
    public RocketController rocketController;

    [Header("UI")]
    public GameObject rocketLauncherButton;
    public GameObject restartButton;
    public TextMeshProUGUI maxHeight;
    public Image fuelImage;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void maxHeightText(int height)
    {
        maxHeight.text = height.ToString();
    }

    public void ImageFilled(float actualFuel, float maxFuel)
    {
        fuelImage.fillAmount = actualFuel / maxFuel;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActiveRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void RocketLauncher()
    {
        rocketController.RocketLauncher();
        rocketLauncherButton.SetActive(false);
    }
}
