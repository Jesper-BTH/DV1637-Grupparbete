using System.Collections;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool Key = false;
    private Animator animator;

    // Audio Jesper
    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;

    private bool soundPlayed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        Key = true;
        animator.SetBool("Key", true);

        if (!soundPlayed)
        {
            StartCoroutine(PlayGateSounds());
            soundPlayed = true;
        }

        Debug.Log("Door opened!");
    }

    private IEnumerator PlayGateSounds()
    {
        src.PlayOneShot(sfx1);
        yield return new WaitForSeconds(0.5f);
        src.PlayOneShot(sfx2);
    }
}