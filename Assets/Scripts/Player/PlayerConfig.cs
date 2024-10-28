using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerConfig", fileName = "Player config")]
public class PlayerConfig : ScriptableObject
{
   public int BaseHealth = 3;
   public int MaxHealth = 5;
}
