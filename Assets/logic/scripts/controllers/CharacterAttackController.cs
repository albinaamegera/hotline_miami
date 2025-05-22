using UnityEngine;

public class CharacterAttackController
{
    private ICharacterController _controller;

    public CharacterAttackController(ICharacterController controller)
    {
        _controller = controller;
    }
    public void Attack()
    {
        Debug.Log("attacking");
    }
}
