using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorUI : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    int currentIndex = 0;
    public GameObject male;
    public GameObject female;
    void Start()
    {
        source.clip = clips[0];
        source.Play();
    }
    void FixedUpdate()
    {
		if (!source.isPlaying && currentIndex < clips.Length-1)
		{
			
            currentIndex++;
            if (currentIndex == 1)
            {
                male.SetActive(true);
            }
            if (currentIndex == 3)
            {
                female.SetActive(true);
                source.clip = clips[currentIndex];
                source.Play();
                currentIndex++;
                return;
            }
            source.clip = clips[currentIndex];
            source.Play();
            return;
		}
        if (currentIndex == clips.Length && !source.isPlaying)
		{
            SceneManager.LoadScene(1);

        }

    }
}
