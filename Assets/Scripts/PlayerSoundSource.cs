using UnityEngine;
using AnnulusGames.LucidTools.Inspector;
using AnnulusGames.LucidTools.RandomKit;
using AnnulusGames.LucidTools.Audio;

[HideMonoScript]
public class PlayerSoundSource : MonoBehaviour
{
    [SerializeField] private double interval;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField, Required] private Rigidbody2D rb2d;
    [SerializeField, Range(0, 1)] private float volume;
    [SerializeField, ReadOnly] private double elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime * rb2d.velocity.magnitude;
        if (elapsedTime > interval)
        {
            LucidAudio.PlaySE(audioClips.RandomElement())
                .SetVolume(volume);
            elapsedTime = 0;
        }
    }
}
