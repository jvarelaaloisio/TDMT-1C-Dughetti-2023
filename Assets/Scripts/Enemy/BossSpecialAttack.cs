using System.Collections;
using UnityEngine;

public class BossSpecialAttack : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;

    public void SpecialAttackCoroutine()
    {
        characterMovement.SpecialAttack();
    }
}
