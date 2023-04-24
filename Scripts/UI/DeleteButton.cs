using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    private CustomButton _customButton;
    void Start()
    {
        _customButton = this.GetComponent<CustomButton>();
        
        _customButton.OnClickCallback = () =>
        {
            CounterText.Instance.Destroy();
        };
    }
}