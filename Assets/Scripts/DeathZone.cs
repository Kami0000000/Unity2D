using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator fadeSystem;
    private void Awake()
    {
        //      GameObject spawnObj = GameObject.FindGameObjectWithTag("PlayerSpawn");
        // if (spawnObj == null)
        // {
        //     Debug.LogError("⚠️ Aucun objet avec le tag PlayerSpawn trouvé !");
        // }
        // else
        // {
        //     playerSpawn = spawnObj.transform;
        //     Debug.Log("✅ PlayerSpawn trouvé à la position " + playerSpawn.position);
        // }
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; //Mettre la postion du joueur sur PlayerSpawn lors de la collision
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Debug.Log("Player a touché la zone de mort !");
            StartCoroutine(ReplacePlayer(collision));


        }
    }
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
        fadeSystem.SetTrigger("FadeOut");
    }
}
