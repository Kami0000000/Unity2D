using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
 private void Awake()
 {
    GameObject.FindWithTag("Player").transform.position=transform.position;
 }
}
