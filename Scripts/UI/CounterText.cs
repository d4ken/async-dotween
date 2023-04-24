using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterText : Singleton<CounterText>
{
    private ReactiveProperty<int> _counter = new ReactiveProperty<int>(0);
    public int addCounter = 0;
    private TextMeshProUGUI _counterText;
    private CancellationToken _ct;
    public int Counter
    {
        get => _counter.Value;
        set
        {
            if (addCounter >= 100)
                addCounter = 0;
            _counter.Value = value;
        }
    }
    
    void Start()
    {
        _ct = this.GetCancellationTokenOnDestroy();
        _counterText = GetComponent<TextMeshProUGUI>();
        _counter
            .DistinctUntilChanged()
            .Subscribe(x =>
            {
                _counterText.text = x.ToString("N0");
            })
            .AddTo(this);
    }
    
    public async UniTask AddCounter(int amount)
    {
        addCounter += amount;
        await DOTween.To(() => Counter, (x) => Counter = x, addCounter, 2f)
            .SetLink(gameObject)
            .ToUniTask(TweenCancelBehaviour.KillAndCancelAwait, _ct);
    }

    public async UniTask MoveAnimation()
    {
        await transform.DOBlendableMoveBy(Vector3.up * 2, 2f)
            .SetEase(Ease.Flash, overshoot: 2)
            .SetLink(gameObject)
            .ToUniTask(TweenCancelBehaviour.KillAndCancelAwait, _ct);
    }

    public void Destroy()
    {
        if (gameObject != null)
            Destroy(gameObject);
    }

}
