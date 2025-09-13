using UnityEngine;

 [System.Serializable]
 public class Dialogue
 {
    public string name;

    [TextArea (3, 10)]//taille dans l'inspecteur
    public string[] sentences;
 }