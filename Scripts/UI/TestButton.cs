using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    private CustomButton _customButton;
    
    void Start()
    {
        _customButton = this.GetComponent<CustomButton>();

        _customButton.OnClickCallback = async () =>
        {
            await CounterText.Instance.AddCounter(10);
        };
    }
}
