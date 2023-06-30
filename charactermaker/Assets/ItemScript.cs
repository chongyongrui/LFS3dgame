using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects")]
public class Item : ScriptableObject
{
    public string id;
    public string name;
    public Sprite icon;
    public bool stackable;
    public GameObject prefab;
    
}
