using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public GameObject fireBallPref;
    public GameObject skeletonPref;
    public Transform aim;
    float speed = 500;
    bool isWizardCreateSceleton = false;

    Animator wizardAnim;
    void Start()
    {
        wizardAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isWizardCreateSceleton)
        {
            isWizardCreateSceleton = true;
            wizardAnim.SetBool("attack", true);
        }
    }
}
