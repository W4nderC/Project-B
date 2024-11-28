using UnityEngine;

public class NpcAnimationControl : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void GetShot()
    {
        animator.SetBool("GetShot", true);
    }
}
