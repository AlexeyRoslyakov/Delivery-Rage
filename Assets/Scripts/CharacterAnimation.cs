using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator; // ������ �� ��������� Animator

    // ������ ����������, ������� � ����������
    [SerializeField] private bool isIdle = false;
    [SerializeField] private bool isWalking = false;
    [SerializeField] private bool isRunning = false;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool isBarking = false;
    [SerializeField] private bool isPunching = false;
    [SerializeField] private bool isStabbing = false;
    [SerializeField] private int animInt = 0;
    [SerializeField] private int weaponInt = 0;

    void Start()
    {
        // �������� ��������� Animator � ���������
        animator = GetComponent<Animator>();

        // ���������, ���� �� Animator
        if (animator == null)
        {
            Debug.Log("Animator component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // ������������� ��������� �������� � ����������� �� �������� ������� ����������
        if (animator != null)
        {
            animator.SetBool("Idle", isIdle);
            animator.SetBool("Walk", isWalking);
            animator.SetBool("Run_b", isRunning);
            animator.SetBool("Jump", isJumping);
            animator.SetBool("Bark_b", isBarking);
            animator.SetBool("Punch_b", isPunching);
            animator.SetBool("Stab_b", isStabbing);
            animator.SetInteger("Animation_int", animInt);
            animator.SetInteger("WeaponType_int", weaponInt);
            
        }
    }
}
