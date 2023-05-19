using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lifeValue;
    [SerializeField] private Slider _lifeSlider;
    
    [SerializeField] private bool _reloadingLeft;

    [SerializeField] private bool _reloadingRight;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnCharacterLifeChange += OnCharacterLifeChange;
        EventManager.instance.OnReloading += OnReloading;
    }

    private void OnCharacterLifeChange(float currentLife, float maxLife)
    {
        _lifeValue.text = currentLife.ToString();
        _lifeSlider.value = currentLife;
    }

    private void OnReloading(Hand hand, bool isReloading)
    {
        //TODO
    }
}
