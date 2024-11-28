using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake() 
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start() 
    {
        GameInput.Instance.OnShotPerformed += GameInput_OnShotPerformed;
    }

    private void GameInput_OnShotPerformed(object sender, EventArgs e)
    {
        animator.SetBool("IsShot", true);
    }

    public void SetShotBool()
    {
        animator.SetBool("IsShot", false);
    }
}
