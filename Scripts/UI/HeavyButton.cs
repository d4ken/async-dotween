using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class HeavyButton : MonoBehaviour
{
    private CustomButton _customButton;
    
    async void Start()
    {
        _customButton = this.GetComponent<CustomButton>();
        
        _customButton.OnClickCallback = async () =>
        {
            try
            {
                await CounterText.Instance.AddCounter(20);
                await CounterText.Instance.MoveAnimation();
            }
            catch (OperationCanceledException)
            {
                Debug.Log("UniTask cancelled.");
            }
            Debug.Log("Completed");
        };
    }
}
