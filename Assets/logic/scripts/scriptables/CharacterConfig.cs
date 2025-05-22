using UnityEngine;
[CreateAssetMenu(menuName = "character config", fileName = "new character config")]
public class CharacterConfig : ScriptableObject
{
    public float movementSpeed;
    public Weapon defaultWeapon;
}
