using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsCount;
    private int counter = 0;

    private void Awake()
    {
        coinsCount = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnCoinCollet()
    {
        counter++;
        coinsCount.text = counter.ToString();
    }
}
