using UnityEngine;
using AnnulusGames.LucidTools.Audio;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip bgmAudioClip;
    [SerializeField, Range(0, 1)] private float volume;

    private void Start()
    {
        LucidAudio.PlayBGM(bgmAudioClip)
            .SetLoop()
            .SetVolume(volume);
    }
}
