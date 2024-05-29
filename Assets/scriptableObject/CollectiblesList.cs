using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectiblesList", menuName = "CollectiblesList")]
 public class CollectiblesList : ScriptableObject

{
    public bool[] isCollected;
    public List<bool> colectedList = new List<bool>();
}
