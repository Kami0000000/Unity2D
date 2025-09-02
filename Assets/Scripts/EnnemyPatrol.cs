using UnityEngine;
public class EnnemyPatrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public Transform[] waypoints;//point de déplacement
    public int damageOnCollision = 20;
    public SpriteRenderer graphics;
    private Transform target;
    private int destpoint = 0;
    void Start()
    {

        damageOnCollision = 20; 
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Si l'ennemi est proche de la cible, on change de cible
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destpoint = (destpoint + 1) % waypoints.Length;
            target = waypoints[destpoint]; 
            graphics.flipX = !graphics.flipX; //Inverse la direction du sprite
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision); // Inflige des dégâts au joueur
         }
     }
}
 