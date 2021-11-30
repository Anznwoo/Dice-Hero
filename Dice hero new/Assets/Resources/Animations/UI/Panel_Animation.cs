using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Animation : MonoBehaviour
{
    public Animator animator;
    public void panelShow()
    {
        animator.SetBool("isOpen", true);
    }
    public void panelHide()
    {
        animator.SetBool("isOpen", false);
    }
}
