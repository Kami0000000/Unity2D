using UnityEngine;
using UnityEngine.UI;
public class PickUpItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Text interactUI;
    private bool isInRange;

    // public Animator animator;
    // public int coinsToAdd;
    public Item item;

    public AudioClip soundToPLay;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
           // Vérifie si cet item a déjà été ramassé
    if (PlayerPrefs.GetInt("ItemPicked_" + item.id, 0) == 1)
    {
        // Si oui, désactive/détruit cet objet pour qu'il ne réapparaisse pas
        Destroy(gameObject);
        return; // on sort de Awake pour ne rien faire d'autre
    }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) &&isInRange)//isInRange= à portée
        {
            TakeItem();
        }   
    }
    void TakeItem()
    {
       Inventory.instance.content.Add(item);
       Inventory.instance.UpdateInventoryUI();
       LoadAndSaveData.instance.SaveData();
       PlayerPrefs.SetInt("ItemPicked_" + item.id, 1);//a été prise
       AudioManager.instance.enabled = false;
       Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
