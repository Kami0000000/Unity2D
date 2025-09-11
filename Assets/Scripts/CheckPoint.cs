using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Transform playerSpawn;
    // private void Awake()
    // {
    //     playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentSceneManager.instance.respawnPoint = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
         }
       
     }
}
