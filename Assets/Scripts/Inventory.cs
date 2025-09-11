using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TextMeshProUGUI coinsCountText;
    //static accessibilié partout 
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance dans la scène");
            return;
        }
        instance = this;
    }
    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
         // Sauvegarde automatique
        LoadAndSaveData.instance.SaveData();
    }
    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
         // Sauvegarde automatique
    LoadAndSaveData.instance.SaveData();
     }
     public void UpdateTextUI()
     {
        coinsCountText.text = coinsCount.ToString();
     }
}
