using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    private CameraMovement cam;
    private Animator playerAnimator;
    private Animator horseAnimator;
    private float maxFOV = 30f;

    void Start()
    {
        cam = GetComponentInParent<CameraMovement>();

        Animator[] animators = transform.root.GetComponentsInChildren<Animator>();
        playerAnimator = animators[0];
        horseAnimator = animators[1];
    }

    void Update()
    {
        if (cam.GetPlayer().HasLost())
        {
            playerAnimator.SetBool("PlayerDeathActive", true);
            return;
        }

        if (cam.speed > 0)
        {
            if (!cam.GetPlayer().OnHorse()) playerAnimator.SetBool("PlayerRunActive", true);
            if (cam.GetPlayer().OnHorse()) horseAnimator.SetBool("PlayerRideActive", true);

            float lerpFactor = cam.speed / cam.maxSpeedPlayer;
            horseAnimator.speed = Mathf.Lerp(horseAnimator.speed, cam.maxSpeedPlayer * 2 / 100, lerpFactor * lerpFactor);
            playerAnimator.speed = Mathf.Lerp(playerAnimator.speed, cam.maxSpeedHorse * 2 / 100, lerpFactor * lerpFactor);

            float FOV = cam.GetComponentInChildren<Camera>().fieldOfView;
            cam.GetComponentInChildren<Camera>().fieldOfView = Mathf.Lerp(FOV, maxFOV, lerpFactor * lerpFactor);
        }
        else
        {
            if (!cam.GetPlayer().OnHorse()) playerAnimator.Play("PlayerIdle");
            if (cam.GetPlayer().OnHorse()) horseAnimator.Play("PlayerHorseIdle");
        }


    }
}
