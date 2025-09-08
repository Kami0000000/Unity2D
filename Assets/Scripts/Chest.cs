using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Text interactUI;
    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
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
            OpenChest();
        }   
    }
    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundToPLay, transform.position); 
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
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
