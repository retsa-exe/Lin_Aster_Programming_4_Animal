using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Blackboards")]
    [SerializeField] private Blackboard foodSpotBlackboard;
    [SerializeField] private Blackboard drinkSpotBlackboard;
    [SerializeField] private Blackboard hamsterBlackboard;

    [Header("UI Sliders")]
    [SerializeField] private Slider foodSpotSlider;
    [SerializeField] private Slider drinkSpotSlider;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider thirstySlider;
    [SerializeField] private Slider energySlider;

    [Header("Variable Names")]
    [SerializeField] private string foodRemainVariableName = "FoodRemain";
    [SerializeField] private string waterRemainVariableName = "WaterRemain";
    [SerializeField] private string hungerVariableName = "HungerValue";
    [SerializeField] private string thirstyVariableName = "ThirstyValue";
    [SerializeField] private string energyVariableName = "EnergyValue";

    [Header("Slider Ranges")]
    [SerializeField] private float foodMaxValue = 100f;
    [SerializeField] private float drinkMaxValue = 100f;
    [SerializeField] private float hungerMaxValue = 100f;
    [SerializeField] private float thirstyMaxValue = 100f;
    [SerializeField] private float energyMaxValue = 100f;

    private void Start()
    {
        RefreshUI();
    }

    private void Update()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        UpdateSlider(foodSpotBlackboard, foodSpotSlider, foodRemainVariableName, foodMaxValue);
        UpdateSlider(drinkSpotBlackboard, drinkSpotSlider, waterRemainVariableName, drinkMaxValue);
        UpdateSlider(hamsterBlackboard, hungerSlider, hungerVariableName, hungerMaxValue);
        UpdateSlider(hamsterBlackboard, thirstySlider, thirstyVariableName, thirstyMaxValue);
        UpdateSlider(hamsterBlackboard, energySlider, energyVariableName, energyMaxValue);
    }

    private void UpdateSlider(Blackboard blackboard, Slider slider, string variableName, float maxValue)
    {
        if (blackboard == null || slider == null)
        {
            return;
        }

        var variable = blackboard.GetVariable<float>(variableName);
        if (variable == null)
        {
            return;
        }

        slider.minValue = 0f;
        slider.maxValue = maxValue;
        slider.value = Mathf.Clamp(variable.value, slider.minValue, slider.maxValue);
    }
}
