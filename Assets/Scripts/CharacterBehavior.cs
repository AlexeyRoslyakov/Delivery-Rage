using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    private Animator animator;
    private float actionTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAction();
    }

    void Update()
    {
        actionTimer -= Time.deltaTime;
        if (actionTimer <= 0)
        {
            ChangeAction();
        }
    }

    void ChangeAction()
    {
        int action = Random.Range(0, 2); // 0 = Idle, 1 = Walk, 2 = Sit, etc.
        switch (action)
        {
            case 0:
                animator.SetFloat("Speed_f", 0); // Idle
                break;
            case 1:
                animator.SetFloat("Speed_f", Random.Range(0.5f, 1.5f)); // Walk
                break;
            case 2:
                animator.SetInteger("Animation_int", 1); // Sit animation trigger
                break;
        }
        actionTimer = Random.Range(5, 15); // Change action every 5-15 seconds
    }
}