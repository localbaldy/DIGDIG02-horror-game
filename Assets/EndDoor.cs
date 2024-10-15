using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;

    public AudioSource doorSound;

    // UI elements for ending
    public GameObject fadeScreen;   // Reference to the fade screen image with Animator
    public Text endingText;         // Text to display before the game ends

    public GameObject doorAnimator;  // Animator for the door (on parent object)

    private bool isEnding = false;

    void Start()
    {
        // Get the Animator component from the parent of the door object



        // Ensure the ending text is hidden at the start
        endingText.gameObject.SetActive(false);
    }

    void Update()
    {
        theDistance = PlayerCasting.DistanceFromTarget;

        if (isEnding) return;  // Prevent further interaction once the ending has started
    }

    private void OnMouseOver()
    {
        if (isEnding) return;

        if (theDistance <= 1)
        {
            actionKey.SetActive(true);
            actionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action") && theDistance <= 3)
        {
            StartEndingSequence();
        }
    }

    private void OnMouseExit()
    {
        if (isEnding) return;
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }

    void StartEndingSequence()
    {
        isEnding = true;
        this.GetComponent<BoxCollider>().enabled = false;
        actionKey.SetActive(false);
        actionText.SetActive(false);

        // Trigger the door animation using the Animator on the parent
        doorAnimator.GetComponent<Animation>().Play("Door anim2");

        doorSound.Play();

        // Start fading and displaying the text
        StartCoroutine(EndGameRoutine());
    }

    IEnumerator EndGameRoutine()
    {
        yield return new WaitForSeconds(1); // Delay to let the door sound play

        // Trigger the fade animation using the Animator
        fadeScreen.SetActive(true);
        endingText.gameObject.SetActive(true);

        // Wait for the fade animation to complete (adjust duration based on your fade animation)
        yield return new WaitForSeconds(1);

        fadeScreen.SetActive(false);
        // Display the ending text
        

        yield return new WaitForSeconds(3); // Keep the text visible for 3 seconds


    }

   
}
