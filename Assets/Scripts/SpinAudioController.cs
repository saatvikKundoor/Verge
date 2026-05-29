using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAudioController : MonoBehaviour
{
    public AudioClip spinSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySpin()
    {
        audioSource.clip = spinSound;
        audioSource.time = 0f;
        audioSource.Play();
        StartCoroutine(StopAfter(5));
    }
    IEnumerator StopAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
