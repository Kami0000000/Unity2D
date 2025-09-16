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
