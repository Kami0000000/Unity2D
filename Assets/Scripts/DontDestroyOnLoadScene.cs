using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public GameObject[] objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
         }
        
    }
}
