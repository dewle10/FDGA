using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesScene1", menuName = "isDeadS1")]
public class EnemiesScene1 : ScriptableObject

{
    public bool[] isDead;
    public List<bool> deadList = new List<bool>();
}
