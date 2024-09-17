using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    public RawImage jumpscareImage;
    public AudioSource jumpscareSound;
    public float flashDuration = 0.5f;

    private void Start()
    {
        jumpscareImage.color = new Color(jumpscareImage.color.r, jumpscareImage.color.g, jumpscareImage.color.b, 0);
    }

    public void TriggerJumpscare()
    {
        StartCoroutine(FlashJumpscare());
    }

    private IEnumerator FlashJumpscare()
    {
        jumpscareImage.color = new Color(jumpscareImage.color.r, jumpscareImage.color.g, jumpscareImage.color.b, 1);
        jumpscareSound.Play();

        yield return new WaitForSeconds(flashDuration);

        jumpscareImage.color = new Color(jumpscareImage.color.r, jumpscareImage.color.g, jumpscareImage.color.b, 0);
    }
}
