using UnityEngine;
using UnityEngine.UI;
public class ShopTrigger : MonoBehaviour
{
    private bool isInRange;
    private Text interactUI;
    public Item[] itemToSell;
    public string pnjName;
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instance.OpenShop(itemToSell, pnjName);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }
     void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            ShopManager.instance.CloseShop();
            //DialogueManager.instance.EndDialogue();
        }
    }
}
