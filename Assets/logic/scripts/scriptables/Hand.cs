using UnityEngine;
[CreateAssetMenu(menuName = "weapons/hand", fileName = "new hand weapon")]
public class Hand : Weapon
{
    public override void Attack()
    {
        Debug.Log("PUNCH !!!");
    }
}
