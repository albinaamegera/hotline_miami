using UnityEngine;

public class CharacterAttackController
{
    private ICharacterController _controller;
    private Weapon _defaultWeapon;
    private Weapon _currentWeapon;
    public CharacterAttackController(ICharacterController controller, Weapon defaultWeapon)
    {
        _controller = controller;
        _defaultWeapon = defaultWeapon;
        _currentWeapon = _defaultWeapon;

        SetUpWeapon();
    }
    public void Attack()
    {
        _currentWeapon.Attack();
    }
    public void SetUpWeapon(Weapon newWeapon)
    {
        _currentWeapon = newWeapon;

        SetUpWeapon();
    }
    private void SetUpWeapon()
    {
        // some logic
    }
}
