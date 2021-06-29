using UnityEngine;

public class Mage : MonoBehaviour
{
    public static Mage mage;
    public int hp;
    public int damage;
    public float moveSpeed;
    private bool canAttack;
    private Animator animator;

    private void Awake()
    {
        if(mage == null)
        {
            mage = this;
        }
        else
        {
            Destroy(this);
        }
        animator = GetComponent<Animator>();
    }

    public void PlayAttackAnim()
    {
        animator.Play("MageAttack");
    }

}
