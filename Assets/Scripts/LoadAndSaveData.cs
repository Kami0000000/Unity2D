using UnityEngine;

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
        // int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        // PlayerHealth.instance.currentHealth = currentHealth;
        // PlayerHealth.instance.healthBar.SetHealth(currentHealth);
    }
    public void SaveData()
    {
          if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
     {
         PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);//stockage de 
         PlayerPrefs.Save();
     }
        
        PlayerPrefs.SetInt("levelReached",CurrentSceneManager.instance.levelToUnlock);
        //PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);//stockage de donnée
        PlayerPrefs.Save();
    } 
  
}
