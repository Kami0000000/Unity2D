using UnityEngine;
using System.Linq;
public class LoadAndSaveData : MonoBehaviour
{
     public static LoadAndSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);//0 default value
        Inventory.instance.UpdateTextUI();

        string[] itemSaved = PlayerPrefs.GetString("inventoryItems", "").Split(',');
        for (int i = 0; i < itemSaved.Length; i++)
        {
            if(itemSaved[i] != "")
            {
             int id = int.Parse(itemSaved[i]);
            Item currentItem = ItemsDatabase.instance.allItems.Single(x=> x.id ==id);
            Inventory.instance.content.Add(currentItem);   
            }
            
        }
        Inventory.instance.UpdateInventoryUI();
        // int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        // PlayerHealth.instance.currentHealth = currentHealth;
        // PlayerHealth.instance.healthBar.SetHealth(currentHealth);
    }
   public void SaveData()
{
    // Sauvegarde des pièces
    PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);

    // Sauvegarde du niveau atteint
    if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
    {
        PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
    }

    // Sauvegarde de l’inventaire sous forme de string (ids séparés par des virgules)
    string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
    PlayerPrefs.SetString("inventoryItems", itemsInInventory);

    PlayerPrefs.Save();
   // Debug.Log("Inventaire sauvegardé : " + itemsInInventory);

    // //chargement
    // string[] itemSaved = itemsInInventory.Split(',');
    // for (int i = 0; i < itemSaved.Length; i++)
    // {
    //     Debug.Log("items: " +itemSaved[i])
    // }
}

  
}
