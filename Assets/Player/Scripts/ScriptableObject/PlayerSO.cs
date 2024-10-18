using UnityEngine;

public enum CombatState
{
    Unoccupied,
    Attack,
}

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public CombatState combatState = CombatState.Unoccupied;
    public bool isGrounded;
    public bool isFalling;
}
