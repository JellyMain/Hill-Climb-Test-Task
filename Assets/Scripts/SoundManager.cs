using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundPackSO soundsPack;



    private void OnEnable()
    {
        Crash.OnPlayerDied += PlayNeckCrackSound;
        Finish.OnPlayerFinished += PlayWinSound;
    }


    private void OnDisable()
    {
        Crash.OnPlayerDied -= PlayNeckCrackSound;
        Finish.OnPlayerFinished -= PlayWinSound;
    }


    private void PlaySound(AudioClip sound, Vector3 position, float volume)
    {
        AudioSource.PlayClipAtPoint(sound, position, volume);
    }


    private void PlayNeckCrackSound(Vector3 playerPos)
    {
        float volume = 1f;
        PlaySound(soundsPack.neckCrack, playerPos, volume);
    }


    private void PlayWinSound()
    {
        float volume = 0.5f;
        PlaySound(soundsPack.winSound, Camera.main.transform.position, volume);
    }
}
