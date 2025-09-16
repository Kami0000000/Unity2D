using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TextMeshProUGUI coinsCountText;
    public List<Item> content =  new List<Item>();
    public int contentCurrentIndex = 0;
    public Image itemImageUI;
    public Text itemNameUI;
    public Sprite emptyItemImage;
    public PlayerEffects playerEffects;
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
    void Start()
    {
        UpdateInventoryUI();
     }
    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        //Utilisation des iTmes et sa suppression
        Item currentItem = content[0];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
        }
    public void GetNextItem()
    {
         if (content.Count == 0)//item -1
        {
            return;
         }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
              UpdateInventoryUI();
        }
    public void GetPreviousItem()
    {
         if (content.Count == 0)//item -1
        {
            return;
         }
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
        }
    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
             itemNameUI.text = "";
        }
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
     public void UpdateTextUI()//recuperer l'image de l'inventaire
     {
        coinsCountText.text = coinsCount.ToString();
     }
}
