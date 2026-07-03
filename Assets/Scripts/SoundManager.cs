using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;
    private AudioClip playing;
    
    public void playSound()
    {
        playing = clip[Random.Range(0, clip.Length-1)];
        audioSource.PlayOneShot(playing);
    }
}
